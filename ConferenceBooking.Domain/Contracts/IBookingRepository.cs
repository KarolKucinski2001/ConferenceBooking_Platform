using ConferenceBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Contracts
{

    public interface IBookingRepository: IRepository<Booking>
    {
        int GetMaxId();
        Booking GetByIdWithDetails(int id);
    }
}
