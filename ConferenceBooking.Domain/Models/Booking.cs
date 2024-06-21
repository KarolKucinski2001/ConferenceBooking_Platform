using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Models
{
    public class Booking
    {
        public int BookingId { get; set; } // Klucz główny

        // Klucz obcy do User
        public int UserId { get; set; }
        public User User { get; set; }

        // Klucz obcy do Room
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
