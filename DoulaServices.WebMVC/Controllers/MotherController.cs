using DoulaServices.Models;
using DoulaServices.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoulaServices.WebMVC.Controllers
{
    [Authorize]
    public class MotherController : Controller
    {
        // GET: Mother
        public ActionResult Index()
        {
            var userId=Guid.Parse(User.Identity.GetUserId());
            var service = new MotherService(userId);
            var model = service.GetMothers();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MotherCreate model)
        {
            if (!ModelState.IsValid) return View(model);            

            var service = CreateMotherService();

            if (service.CreateMother(model))
            {
                TempData["SaveResult"] = "You added a new mother.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "New mother could not be added.");

            return View(model);
        }

        private MotherService CreateMotherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MotherService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMotherService();
            var model = svc.GetMotherById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMotherService();
            var detail = service.GetMotherById(id);
            var model =
                new MotherEdit
                {
                    MotherId = detail.MotherId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    MotherLocation = detail.MotherLocation,
                    DueDate = detail.DueDate,
                    BreastFeeding = detail.BreastFeeding
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MotherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.MotherId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateMotherService();

            if (service.UpdateMother(model))
            {
                TempData["SaveResult"] = "The file was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The file could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMotherService();
            var model = svc.GetMotherById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMother(int id)
        {
            var service = CreateMotherService();

            service.DeleteMother(id);

            TempData["SaveResult"] = "Mother was deleted";

            return RedirectToAction("Index");
        }
    }
}