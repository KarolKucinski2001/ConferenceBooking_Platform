using ConferenceBooking.SharedKernel.Dto.Booking;
using Newtonsoft.Json;

namespace BlazorClient.Services
{
    public interface IBookingService
    {
        // dalem referencje do BookingDto, ale tu powinien być jakiś viewmodel zrobiony w tym projekcie na front
        Task<BookingDto> GetByIdWithDetails(int id);
        Task<List<BookingDto>> GetAll();
        Task<int> Create(BookingDto dto);

    }
    public class BookingService:IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
        }

        public async Task<BookingDto> GetByIdWithDetails(int id)
        {
            try
            {
                _httpClient.BaseAddress = new Uri ("https://localhost:7036");
                var response = await _httpClient.GetAsync($"/booking?id={id}");
                var content = await response.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<BookingDto> (content);
                return booking;
            }
            catch(Exception ex)
            {
                //logowanie
                return null;
            }
            
        }

        public Task<List<BookingDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(BookingDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
