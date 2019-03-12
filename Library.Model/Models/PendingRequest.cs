using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Models
{
    public class PendingRequest
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public int ChoosenRoomID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public bool Pending { get; set; }

        [ForeignKey("Username")]
        public Account Account { get; set; }

        [ForeignKey("ChoosenRoomID")]
        public Room Room { get; set; }
    }
}
