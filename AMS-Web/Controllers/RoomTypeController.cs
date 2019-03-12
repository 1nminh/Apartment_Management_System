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
    public class RoomTypeController : Controller
    {
        private IRepository<RoomType> roomTypeRepository;

        public RoomTypeController()
        {
            this.roomTypeRepository = new Repository<RoomType>();
        }

        public ActionResult Index()
        {
            var result = roomTypeRepository.GetAll();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoomType apartment)
        {
            roomTypeRepository.Create(apartment);
            return RedirectToAction("Index", "RoomType");
        }

        public ActionResult Edit(int id)
        {
            var result = roomTypeRepository.Get(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(RoomType apartment)
        {
            roomTypeRepository.Update(apartment);
            return RedirectToAction("Index", "RoomType");
        }

        public ActionResult Delete(int id)
        {
            var result = roomTypeRepository.Get(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(RoomType apartment)
        {
            roomTypeRepository.Delete(apartment.ID);
            return RedirectToAction("Index", "RoomType");
        }

    }
}