using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Models
{
    public class Period
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public int RoomID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime JoinedDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ExpiryDate { get; set; }

        public bool isActive { get; set; }

        [ForeignKey("RoomID")]
        public Room Room { get; set; }

        [ForeignKey("Username")]
        public Account Account { get; set; }

        public ICollection<RoomPayLog> RoomPayLogs { get; set; }
    }
}