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
    public class DoulaController : Controller
    {
        // GET: Doula
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DoulaService(userId);
            var model = service.GetDoulas();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoulaCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDoulaService();

            if (service.CreateDoula(model))
            {
                TempData["SaveResult"] = "You added a new Doula.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "New doula could not be added.");

            return View(model);
        }

        private DoulaService CreateDoulaService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DoulaService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDoulaService();
            var model = svc.GetDoulaById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDoulaService();
            var detail = service.GetDoulaById(id);
            var model =
                new DoulaEdit
                {
                    DoulaId = detail.DoulaId,
                    DoulaLocation = detail.DoulaLocation,
                    AvailJan = detail.AvailJan,
                    AvailFeb = detail.AvailFeb,
                    AvailMar = detail.AvailMar,
                    AvailApr = detail.AvailApr,
                    AvailMay = detail.AvailMay,
                    AvailJun = detail.AvailJun,
                    AvailJul = detail.AvailJul,
                    AvailAug = detail.AvailAug,
                    AvailSep = detail.AvailSep,
                    AvailOct = detail.AvailOct,
                    AvailNov = detail.AvailNov,
                    AvailDec = detail.AvailDec
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DoulaEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.DoulaId != id)
            {
                ModelState.AddModelError("", "ID MisMatch");
                return View(model);
            }

            var service = CreateDoulaService();

            if (service.UpdateDoula(model))
            {
                TempData["SaveResult"] = "The profile has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The profile could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDoulaService();
            var model = svc.GetDoulaById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDoula(int id)
        {
            var service = CreateDoulaService();

            service.DeleteDoula(id);

            TempData["SaveResult"] = "Doula was removed";

            return RedirectToAction("Index");
        }
    }
}