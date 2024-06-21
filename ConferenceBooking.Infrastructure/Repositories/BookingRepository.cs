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

        public int GetMaxId()
        {
            if (!_conferenceDbContext.Bookings.Any())
                return 1;

            return _conferenceDbContext.Bookings.Max(x => x.BookingId);
        }

        public Booking GetByIdWithDetails(int id)
        {
            var booking = _conferenceDbContext.Bookings
                .Include(o => o.Room)
                .Where(o => o.BookingId == id)
                .FirstOrDefault();

            return booking;
        }
    }
}
