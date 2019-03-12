using Library.BLL;
using Library.IBLL;
using Library.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMS_Web.Controllers
{
    public class ServiceController : Controller
    {
        private IRepository<Service> serviceRepository;

        public ServiceController()
        {
            this.serviceRepository = new Repository<Service>();
        }

        public ActionResult Index()
        {
            var result = serviceRepository.GetAll();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Service service)
        {
            serviceRepository.Create(service);
            return RedirectToAction("Index", "Service");
        }

        public ActionResult Edit(int id)
        {
            var result = serviceRepository.Get(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Service service)
        {
            serviceRepository.Update(service);
            return RedirectToAction("Index", "Service");
        }

        public ActionResult Delete(int id)
        {
            var result = serviceRepository.Get(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(Service service)
        {
            serviceRepository.Delete(service.ID);
            return RedirectToAction("Index", "Service");
        }
    }
}