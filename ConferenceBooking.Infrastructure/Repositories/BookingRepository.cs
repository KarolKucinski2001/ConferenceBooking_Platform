using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceBooking.Domain.Models;
using ConferenceBooking.Domain.Contracts;

namespace ConferenceBooking.Infrastructure.Repositories
{
    public class BookingRepository: Repository<Booking>, IBookingRepository
    {
        private readonly ConferenceDbContext _conferenceDbContext;

        public BookingRepository(ConferenceDbContext context)
            : base(context)
        {
            _conferenceDbContext = context;
        }

        public List<Booking> GetAll()
        {
            return _conferenceDbContext.Bookings.ToList();
        }

        public Booking Get(int id)
        {
            var booking = _conferenceDbContext.Bookings
                .Include(o => o.Room)
                .Where(o => o.BookingId == id)
                .FirstOrDefault();

            return booking;
        }
        public bool BookingExists(int id)
        {
            var result = _conferenceDbContext.Bookings.Any(x => x.BookingId == id);
            return result;
        }
    }
}
