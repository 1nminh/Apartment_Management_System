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
    public class ApartmentController : Controller
    {
        private IRepository<Apartment> apartmentRepository;

        public ApartmentController()
        {
            this.apartmentRepository = new Repository<Apartment>();
        }

        public ActionResult Index()
        {
            var result = apartmentRepository.GetAll();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Apartment apartment)
        {
            apartmentRepository.Create(apartment);
            return RedirectToAction("Index", "Apartment");
        }

        public ActionResult Edit(int id)
        {
            var result = apartmentRepository.Get(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Apartment apartment)
        {
            apartmentRepository.Update(apartment);
            return RedirectToAction("Index", "Apartment");
        }

        public ActionResult Delete(int id)
        {
            var result = apartmentRepository.Get(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(Apartment apartment)
        {
            apartmentRepository.Delete(apartment.ID);
            return RedirectToAction("Index", "Apartment");
        }

        public ActionResult Details(int id)
        {
            //var result = apartmentRepository.Get(x => x.ID == id, y => y.Rooms);
            return RedirectToAction("LoadApartmentRoom", "Room", new { id = id });
        }
    }
}