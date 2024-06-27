
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceBooking.SharedKernel.Dto.Room;
using ConferenceBooking.SharedKernel.Dto.User;

namespace ConferenceBooking.SharedKernel.Dto.Booking
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public UserDto User { get; set; }
        public RoomDto Room { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
