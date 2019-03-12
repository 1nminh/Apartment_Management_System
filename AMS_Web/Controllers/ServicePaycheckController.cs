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
    public class ServicePaycheckController : Controller
    {

        private IRepository<ServicePaycheck> servicePaycheckRepository;

        public ServicePaycheckController()
        {
            this.servicePaycheckRepository = new Repository<ServicePaycheck>();
        }

        public ActionResult Index()
        {
            var result = servicePaycheckRepository.GetAll();
            return View(result);
        }

        public ActionResult Create()
        {
            IRepository<Service> serviceRepository = new Repository<Service>();
            var service = serviceRepository.GetAll();
            ViewBag.services = service;
            return View();
        }

        [HttpPost]
        public ActionResult Create(string username, int serviceID, int amount)
        {
            IRepository<Service> serviceRepository = new Repository<Service>();
            var service = serviceRepository.Get(x => x.ID == serviceID);
            int money = amount * service.Price;

            servicePaycheckRepository.Create(new ServicePaycheck
            {
                Username = username,
                ServiceID = serviceID,
                Amount = amount,
                Money = money,
                Paid = false,
                DateCreated = DateTime.Now,
                DateOfPayment = new DateTime(2001, 1, 1)
            });
            return RedirectToAction("Index", "ServicePaycheck");
        }

        public ActionResult CreateServiceForRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateServiceForRoom(int roomID, int serviceID, int amount)
        {
            IRepository<Period> periodRepository = new Repository<Period>();
            IRepository<Service> serviceRepository = new Repository<Service>();

            var service = serviceRepository.Get(x => x.ID == serviceID);
            var period = periodRepository.GetAll(x => x.RoomID == roomID && x.isActive == true);

            int count = period.Count();
            int money = amount * service.Price;
            int moneyEach = money / count;
            int amountEach = amount / count;

            foreach (var item in period)
            {
                servicePaycheckRepository.Create(new ServicePaycheck
                {
                    Username = item.Username,
                    ServiceID = serviceID,
                    Amount = amountEach,
                    Money = moneyEach,
                    Paid = false,
                    DateCreated = DateTime.Now,
                    DateOfPayment = new DateTime(2001, 1, 1)
                });
            }
            return View();
        }
    }
}