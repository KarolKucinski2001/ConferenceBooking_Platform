using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.SharedKernel.Dto.Booking;
using ConferenceBooking.SharedKernel.Dto.Room;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceBooking.WebAPi.Controllers
{


    [Route("[controller]")]
    [ApiController]
    public class BookingController:Controller
    {

        private readonly IBookingService _bookingService;

        public BookingController(IBookingService orderService)
        {
            this._bookingService = orderService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<RoomDto>> GetAll()
        {
            var result = _bookingService.GetAll();
            return Ok(result);
        }    
        [HttpGet]
        public ActionResult<IEnumerable<RoomDto>> Get(int id)
        {
            var result = _bookingService.GetByIdWithDetails(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] BookingDto dto)
        {
            var id = _bookingService.Create(dto);

            var actionName = nameof(Get);
            var routeValues = new { id };
            return CreatedAtAction(actionName, routeValues, null);
        }
    }
}
