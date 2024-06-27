using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.SharedKernel.Dto.User
{
    public class UpdateUserDto
    {
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
