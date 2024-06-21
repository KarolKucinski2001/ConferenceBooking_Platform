
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.SharedKernel.Dto
{
    public class BookingDto
    {
        public int BookingId { get; set; } // Klucz główny

        // Klucz obcy do User
        public int UserId { get; set; }
        public UserDto User { get; set; }

        // Klucz obcy do Room
        public int RoomId { get; set; }
        public RoomDto Room { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
