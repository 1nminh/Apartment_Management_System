using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }
        public int ApartmentID { get; set; }
        public int RoomTypeID { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }        
        public int Floor { get; set; }
        public bool Available { get; set; }

        public ICollection<Period> Periods { get; set; }
        public ICollection<PendingRequest> PendingRequests { get; set; }

        [ForeignKey("ApartmentID")]
        public Apartment Apartment { get; set; }

        [ForeignKey("RoomTypeID")]
        public RoomType RoomType { get; set; }
    }
}
