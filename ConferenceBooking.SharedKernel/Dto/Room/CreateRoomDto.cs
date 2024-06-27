using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.SharedKernel.Dto.Room
{
    public class CreateRoomDto
    {
        public int RoomId { get; set; } 
        public string RoomName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        //public string ImageUrl { get; set; } = "/images/no-image-icon.png";






    }
}
