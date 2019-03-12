using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Models
{
    public class RoomPayLog
    {
        [Key]
        public int ID { get; set; }
        public int PeriodID { get; set; }
        public string Username { get; set; }
        public int Amount { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public string Note { get; set; }

        [ForeignKey("PeriodID")]
        public Period Period { get; set; }

        [ForeignKey("Username")]
        public Account Account { get; set; }
    }
}
