using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.ViewModels
{
    public class PeriodViewModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public int RoomID { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool isActive { get; set; }
    }
}