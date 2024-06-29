using ConferenceBooking.SharedKernel.Dto.Booking;
using Newtonsoft.Json;
using System.Net.Http;

namespace BlazorClient.Services
{
 
    public class BookingService:IBookingService  
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

      
        public async Task<List<BookingDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("/booking");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var bookings = JsonConvert.DeserializeObject<IEnumerable<BookingDto>>(content);

                return bookings.ToList();
            }

            return new List<BookingDto>();
        }


        public async Task<BookingDto> GetById(int id)
        {

            try
            {
                _httpClient.BaseAddress = new Uri("https://localhost:7036");
                var response = await _httpClient.GetAsync($"/booking?id={id}");
                var content = await response.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<BookingDto>(content);
                return booking;
            }
            catch (Exception ex)
            {
                //logowanie
                return null;
            }

        }

    }
}
