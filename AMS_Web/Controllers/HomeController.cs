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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult TotalMoneyEarned()
        {
            IRepository<RoomPayLog> roomPayLogRepository = new Repository<RoomPayLog>();
            IRepository<ServicePaycheck> servicePaycheckRepository = new Repository<ServicePaycheck>();

            var roompay = roomPayLogRepository.GetAll();
            var servicepay = servicePaycheckRepository.GetAll(x => x.Paid == true);

            decimal total = 0;

            foreach (var item in roompay)
            {
                total += item.Amount;
            }

            foreach (var item in servicepay)
            {
                total += item.Money;
            }

            return Content(total.ToString());
        }

        public ActionResult TotalMoneyEarnedInMonth()
        {
            IRepository<RoomPayLog> roomPayLogRepository = new Repository<RoomPayLog>();
            IRepository<ServicePaycheck> servicePaycheckRepository = new Repository<ServicePaycheck>();

            var roomPay = roomPayLogRepository.GetAll();
            var servicePay = servicePaycheckRepository.GetAll(x => x.Paid == true);

            var roomPayMonth = roomPay.Where(x => x.Date.Month.Equals(DateTime.Now.Month) && x.Date.Year == DateTime.Now.Year);
            var servicePayMonth = servicePay.Where(x => x.DateOfPayment.Month.Equals(DateTime.Now.Month) && x.DateOfPayment.Year == DateTime.Now.Year);

            decimal total = 0;

            foreach (var item in roomPayMonth)
            {
                total += item.Amount;
            }

            foreach (var item in servicePayMonth)
            {
                total += item.Money;
            }

            return Content(total.ToString());
        }
    }
}