using ConferenceBooking.SharedKernel.Dto.Booking;

namespace BlazorClient.Services
{
    public interface IBookingService
    {
        Task<List<BookingDto>> GetAll();
        Task<BookingDto> GetById(int id);

    }
}
