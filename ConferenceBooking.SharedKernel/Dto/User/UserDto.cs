using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceBooking.SharedKernel.Dto.Booking;

namespace ConferenceBooking.SharedKernel.Dto.User
{
    public class UserDto
    {
        public int UserId { get; set; } // Klucz główny
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Relacja 1:M z Booking
        //public ICollection<BookingDto> BookingsDto { get; set; }
    }
}
