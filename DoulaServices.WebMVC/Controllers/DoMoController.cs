using DoulaServices.Models.DoMo;
using DoulaServices.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoulaServices.WebMVC.Controllers
{
    public class DoMoController : Controller
    {
        // GET: DoMo
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DoMoAssServices(userId);
            var model = service.GetDoMos();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Create model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDoMoService();

            if (service.CreateDoMo(model))
            {
                TempData["Save Result"] = "You added a new pairing.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "New pairing could not be added.");

            return View(model);
        }

        private DoMoAssServices CreateDoMoService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DoMoAssServices(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDoMoService();
            var model = svc.GetDoMoById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDoMoService();
            var detail = service.GetDoMoById(id);
            var model =
                new Edit
                {
                    DoMoId = detail.DoMoId,
                    DoulaName = detail.DoulaName,
                    FirstName = detail.FirstName,
                    Notes = detail.Notes
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Edit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if (model.DoMoId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDoMoService();

            if (service.UpdateDoMo(model))
            {
                TempData["SaveResult"] = "The pairing has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The pairing could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDoMoService();
            var model = svc.GetDoMoById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDoMo(int id)
        {
            var service = CreateDoMoService();

            service.DeleteDoMo(id);

            TempData["SaveResult"] = "Pairing was removed.";

            return RedirectToAction("Index");
        }
    }
}