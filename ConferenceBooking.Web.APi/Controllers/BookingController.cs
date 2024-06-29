using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.Domain.Exceptions;
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
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService orderService, ILogger<BookingController> logger)
        {
            this._bookingService = orderService;
            _logger = logger;   
        }

        [HttpGet ("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<RoomDto>> GetAll()
        {
            var result = _bookingService.GetAll();
            _logger.LogDebug("Pulled a list of all bookings");
            return Ok(result);
        }


        [HttpGet("{id}", Name = "GetBooking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDto> Get(int id)
        {
            var result = _bookingService.GetById(id);
            _logger.LogDebug($"Pulled a booking with id = {id}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateBookingDto dto)
        {
            var id = _bookingService.Create(dto);
            _logger.LogDebug($"Created new booking with id = {id}");
            var actionName = nameof(Get);
            var routeValues = new { id };
            return CreatedAtAction(actionName, routeValues, null);
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateBookingDto dto)
        {
            if (id != dto.BookingId)
            {
                throw new BadRequestException("Id param is not valid");
            }

            _bookingService.Update(dto);
            _logger.LogDebug($"Updated booking with id = {id}");
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            _bookingService.Delete(id);
            _logger.LogDebug($"Deleted booking with id = {id}");
            return NoContent();
        }

    }
}
