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
        public List<Booking> GetAll();
        public Booking Get(int id);
        public bool BookingExists(int id);



        //int GetMaxId();
        //Booking GetByIdWithDetails(int id);
    }
}
