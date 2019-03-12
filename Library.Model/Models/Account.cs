using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Models
{
    public class Account
    {
        [Key]
        public string Username { get; set; }

        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string IdCardNumber { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        public int Balance { get; set; }
        public bool IsActive { get; set; }

        public ICollection<FeedBack> FeedBacks { get; set; }

        public ICollection<PendingRequest> PendingRequests { get; set; }

        public ICollection<ServicePaycheck> ServicePayChecks { get; set; }

        public ICollection<Period> Periods { get; set; }

        public ICollection<RoomPayLog> RoomPayLogs { get; set; }


    }
}
