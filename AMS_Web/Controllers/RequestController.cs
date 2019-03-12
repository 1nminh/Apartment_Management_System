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
    public class RequestController : Controller
    {
        private IRepository<PendingRequest> requestRepository;

        public RequestController()
        {
            this.requestRepository = new Repository<PendingRequest>();
        }

        public ActionResult Index()
        {
            var result = requestRepository.GetAll();
            return View(result);
        }

        public ActionResult RoomFull()
        {
            var result = requestRepository.GetAll();
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var result = requestRepository.Get(x => x.ID == id && x.Pending == true);
            ViewBag.request = result;
            return RedirectToAction("RequestRoom", "Request", new { id = id, username = result.Username, roomID = result.ChoosenRoomID });
        }

        public ActionResult Delete(int id)
        {
            requestRepository.Delete(id);
            return RedirectToAction("Index", "Request");
        }

        public ActionResult RequestRoom(int id, string username, int roomID)
        {
            IRepository<Room> roomRepository = new Repository<Room>();
            IRepository<Period> periodRepository = new Repository<Period>();

            var onApartment = periodRepository.Get(x => x.Username.Equals(username) && x.isActive == true);
            var room = roomRepository.Get(x => x.ID == roomID);
            var period = periodRepository.GetAll(x => x.RoomID == roomID && x.isActive == true);

            if (onApartment != null)
            {
                int capacity = room.Capacity;
                int count = period.Count();

                if (count == capacity)
                {
                    return RedirectToAction("RoomFull", "Request");
                }

                if (count < capacity)
                {
                  

                    onApartment.isActive = false;
                    periodRepository.Update(onApartment);

                    periodRepository.Create(new Period
                    {
                        Username = username,
                        RoomID = roomID,
                        JoinedDate = DateTime.Now,
                        ExpiryDate = new DateTime(2001, 1, 1),
                        isActive = true
                    });

                    requestRepository.Delete(id);

                    if (count == capacity - 1)
                    {
                        room = roomRepository.Get(x => x.ID == roomID);
                        room.Available = false;
                        roomRepository.Update(room);
                    }
                    return RedirectToAction("Index", "Request");
                }


            }
            else
            {
                int capacity = room.Capacity;
                int count = period.Count();

                if (count == capacity)
                {
                    return RedirectToAction("RoomFull", "RoomFull");
                }

                if (count < capacity)
                {
                    periodRepository.Create(new Period
                    {
                        Username = username,
                        RoomID = roomID,
                        JoinedDate = DateTime.Now,
                        ExpiryDate = new DateTime(2001, 1, 1),
                        isActive = true
                    });
                    requestRepository.Delete(id);
                    return RedirectToAction("Index", "Request");
                }
            }
            return View();
        }
    }
}