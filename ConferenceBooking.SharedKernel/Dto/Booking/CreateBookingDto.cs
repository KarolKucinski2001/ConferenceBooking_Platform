using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.SharedKernel.Dto.Booking
{
    public class CreateBookingDto
    {
        public int RoomId {get; set;}
        public int UserId { get; set;}
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
}
