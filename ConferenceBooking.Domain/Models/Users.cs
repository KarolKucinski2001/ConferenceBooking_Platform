using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } // Klucz główny
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Relacja 1:M z Booking
        public ICollection<Booking> Bookings { get; set; }
    }
}
