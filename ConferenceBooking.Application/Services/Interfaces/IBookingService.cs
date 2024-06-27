using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Domain.Models;
using ConferenceBooking.SharedKernel.Dto.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services.Interfaces
{
    public interface IBookingService
    {
        List<BookingDto> GetAll();
        BookingDto GetById(int id);
        int Create(CreateBookingDto dto);
        void Update(UpdateBookingDto dto);
        void Delete(int id);
    }
}
