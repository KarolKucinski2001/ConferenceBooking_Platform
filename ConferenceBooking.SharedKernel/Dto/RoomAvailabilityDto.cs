﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.SharedKernel.Dto
{
    public  class RoomAvailabilityDto
    {
        public int AvailabilityId { get; set; } // Klucz główny

        // Klucz obcy do Room
        public int RoomId { get; set; }
        public RoomDto RoomDto { get; set; }

        public DateTime AvailableDate { get; set; }
        public bool IsAvailable { get; set; }

        // Relacja 1:M z Booking (dodatkowa relacja)
        public ICollection<BookingDto> BookingsDto { get; set; }
    }
}
