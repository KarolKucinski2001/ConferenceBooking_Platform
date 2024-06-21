using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.SharedKernel.Dto
{
    public class EquipmentDto
    {
        public int EquipmentId { get; set; } // Klucz główny

        // Klucz obcy do Room
        public int RoomId { get; set; }
        public RoomDto RoomDto { get; set; }

        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
    }
}
