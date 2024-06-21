using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.SharedKernel.Dto
{
    public class UpdateRoomDto
    {
        public int RoomId { get; set; } // Klucz główny
        public string RoomName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; } = "/images/no-image-icon.png";

        // Relacja 1:M z Booking
        public ICollection<BookingDto> Bookings { get; set; }

        // Relacja 1:M z Equipment
        public ICollection<EquipmentDto> Equipments { get; set; }

        // Relacja 1:M z RoomAvailability
        public ICollection<RoomAvailabilityDto> RoomAvailabilities { get; set; }
    }
}
