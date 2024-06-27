using ConferenceBooking.SharedKernel.Dto.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.SharedKernel.Dto.Equipment
{
    public class CreateEquipmentDto
    {
        public int RoomId { get; set; }
        public RoomDto RoomDto { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
    }
}
