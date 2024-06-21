using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Models
{
    public class Room
    {
        public int RoomId { get; set; } // Klucz główny
        public string RoomName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        // Relacja 1:M z Booking
        public ICollection<Booking> Bookings { get; set; }

        // Relacja 1:M z Equipment
        public ICollection<Equipment> Equipments { get; set; }

        // Relacja 1:M z RoomAvailability
        public ICollection<RoomAvailability> RoomAvailabilities { get; set; }
    }
}
