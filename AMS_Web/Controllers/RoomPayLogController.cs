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
    public class RoomPayLogController : Controller
    {
        private IRepository<RoomPayLog> roomPayLogRepository;

        public RoomPayLogController()
        {
            this.roomPayLogRepository = new Repository<RoomPayLog>();
        }
        // GET: RoomPayLog
        public ActionResult Index()
        {
            var result = roomPayLogRepository.GetAll();
            return View(result);
        }
    }
}