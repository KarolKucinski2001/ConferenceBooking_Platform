using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Exceptions
{
    // Wyjątek: Obiekt nie został znaleziony
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
