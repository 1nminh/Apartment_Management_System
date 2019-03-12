using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.ViewModels
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        public int ApartmentID { get; set; }
        public int RoomTypeID { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool Available { get; set; }

        public ICollection<PeriodViewModel> Periods { get; set; }
    }
}