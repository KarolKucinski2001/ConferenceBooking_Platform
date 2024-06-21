using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.SharedKernel.Dto
{
    public class RoomDto
    {
        public int RoomId { get; set; } // Klucz główny
        public string RoomName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
}
