using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Models
{
    public class ServicePaycheck
    {
        [Key]
        public int ID { get; set; }

        public string Username { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfPayment { get; set; }

        public int ServiceID { get; set; }
        public int Amount { get; set; }
        public int Money { get; set; }
        public bool Paid { get; set; }

        [ForeignKey("Username")]
        public Account Account { get; set; }

        [ForeignKey("ServiceID")]
        public Service Service { get; set; }
    }
}
