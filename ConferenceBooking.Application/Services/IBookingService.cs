using ConferenceBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services
{
    public interface IBookingService
    {
        int Create(BookingDto dto);
        List<BookingDto> GetAll();
        BookingDto GetByIdWithDetails(int id);
    }
}
