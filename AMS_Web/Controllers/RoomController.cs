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
    public class RoomController : Controller
    {
        private IRepository<Room> roomRepository;

        public RoomController()
        {
            this.roomRepository = new Repository<Room>();
        }

        // GET: Room
        public ActionResult Index()
        {
            var result = roomRepository.GetAll();
            return View(result);
        }

        public ActionResult Create()
        {
            IRepository<Apartment> apartmentRepository = new Repository<Apartment>();
            IRepository<RoomType> roomTypeRepository = new Repository<RoomType>();

            var resultAp = apartmentRepository.GetAll();
            var resultRoomType = roomTypeRepository.GetAll();

            ViewBag.apartments = resultAp;
            ViewBag.roomTypes = resultRoomType;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            room.Available = true;
            roomRepository.Create(room);
            return RedirectToAction("Index", "Room");
        }

        public ActionResult Edit(int id)
        {
            var result = roomRepository.Get(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            roomRepository.Update(room);
            return RedirectToAction("Index", "Room");
        }

        public ActionResult Delete(int id)
        {
            var result = roomRepository.Get(x => x.ID == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(Room room)
        {
            roomRepository.Delete(room.ID);
            return RedirectToAction("Index", "Room");
        }

        public ActionResult TotalRoomCount()
        {
            var result = roomRepository.GetAll().Count();
            return Content(result.ToString());
        }

        public ActionResult TotalRoomAvailable()
        {
            var result = roomRepository.GetAll(x => x.Available == true).Count();
            return Content(result.ToString());
        }

        public ActionResult LoadApartmentRoom(int id)
        {
            var result = roomRepository.GetAll(x => x.ApartmentID == id);
            return View("Index", result);
        }

        public ActionResult Details(int id)
        {
            //var result = apartmentRepository.Get(x => x.ID == id, y => y.Rooms);
            return RedirectToAction("LoadRoomPeople", "Period", new { id = id });
        }
    }
}