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
    public class PeriodController : Controller
    {
        private IRepository<Period> periodRepository;

        public PeriodController()
        {
            this.periodRepository = new Repository<Period>();
        }

        public ActionResult Index()
        {
            var result = periodRepository.GetAll(x => x.isActive == true);
            return View(result);
        }

        public ActionResult TotalPeopleInAparment()
        {
            var result = periodRepository.GetAll(x => x.isActive == true).Count();
            return Content(result.ToString());
        }

        public ActionResult LoadRoomPeople(int id)
        {
            var result = periodRepository.GetAll(x => x.isActive == true && x.RoomID == id);
            return View("Index", result);
        }


        public ActionResult PayRentForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PayTheRent(string username, int amount)
        {
            var period = periodRepository.Get(x => x.Username.Equals(username) && x.isActive == true);
            if (period != null)
            {
                IRepository<Room> roomRepository = new Repository<Room>();
                var room = roomRepository.Get(x => x.ID == period.RoomID);
                if (room != null)
                {
                    IRepository<RoomType> roomTypeRepository = new Repository<RoomType>();
                    var roomType = roomTypeRepository.Get(x => x.ID == room.RoomTypeID);
                    if (roomType != null)
                    {
                        IRepository<Account> accountRepository = new Repository<Account>();
                        var account = accountRepository.Get(x => x.Username.Equals(username));
                        if (account != null)
                        {
                            int times = (amount + account.Balance) / roomType.Price;
                            for (int i = 0; i < times; i++)
                            {
                                period.ExpiryDate = period.ExpiryDate.AddDays(30);
                            }
                            int moneyPaid = times * roomType.Price;

                            account.Balance = (amount + account.Balance) - moneyPaid;
                            IRepository<RoomPayLog> roomPayLogRepository = new Repository<RoomPayLog>();

                            accountRepository.Update(account);
                            periodRepository.Update(period);
                            roomPayLogRepository.Create(new RoomPayLog
                            {
                                PeriodID = period.ID,
                                Username = period.Username,
                                Amount = amount,
                                Date = DateTime.Now,
                                Note = "pay for " + times + " month(s) - residual = " + account.Balance
                            });
                            return RedirectToAction("Index", "Period");
                        }
                        return View("Error");
                    }
                    return View("Error");
                }
                return View("Error");
            }
            return View("Error");
        }
    }
}