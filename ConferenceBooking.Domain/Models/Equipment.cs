using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; } // Klucz główny

        // Klucz obcy do Room
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
    }
}
