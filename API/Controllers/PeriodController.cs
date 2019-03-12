using Library.BLL;
using Library.IBLL;
using Library.Model.Models;
using System;
using System.Web.Http;

namespace API.Controllers
{
    public class PeriodController : ApiController
    {
        private readonly IRepository<Period> periodRepository;

        public PeriodController()
        {
            this.periodRepository = new Repository<Period>();
        }

        // GET: GetListRoomAndUser
        [HttpGet]
        public IHttpActionResult GetListRoomAndUser(int roomID, bool isActive)
        {
            var result = periodRepository.GetAll(x => x.RoomID == roomID && x.isActive == true);
            return Ok(result);
        }

        // GET: GetUserRoomID
        [HttpGet]
        public IHttpActionResult GetUserRoom(string username, bool IsActive)
        {
            var result = periodRepository.Get(x => x.Username.Equals(username) == true && x.isActive == IsActive);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult PayTheRent(string username, int amount)
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
                            return Ok();
                        }
                        return BadRequest("Account not valid");
                    }
                    return BadRequest("Room type not valid");
                }
                return BadRequest("Room not valid");
            }
            return BadRequest("User not in any room");
        }

    }
}
