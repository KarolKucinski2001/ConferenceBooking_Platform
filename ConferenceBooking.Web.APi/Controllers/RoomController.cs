using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.Domain.Exceptions;
using ConferenceBooking.SharedKernel.Dto.Room;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceBooking.WebAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController:Controller
    {
        private readonly IRoomService _roomService;
        private readonly ILogger<RoomController> _logger;

        //private readonly IValidator<CreateRoomDto> _validator;

        //public ProductController(IProductService productService, IValidator<CreateRoomDto> validator)
        //{
        //    this._oomService = roomService;
        //    _validator = validator;
        //}

        public RoomController(IRoomService roomService, ILogger<RoomController> logger)
        {
            this._roomService = roomService;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDto>> Get()
        {
            var result = _roomService.GetAll();
            _logger.LogDebug("Pobrano listę wszystkich pokoji");
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetRoom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoomDto> Get(int id)
        {
            var result = _roomService.GetById(id);
            _logger.LogDebug($"Pobrano pokój o id = {id}");
            return Ok(result);
        }


        // return CreatedAtAction() - dynamicznie twrozony url
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateRoomDto dto)
        {
            // 1. Atrybut [ApiController]                               --> uruchamia automatyczną walidację
            // 2. Brak atrybutu [ApiController]                         --> automatyczna walidacja nie jest uruchamiania 
            // 3. Brak atrybutu [ApiController] + ModelState.IsValid    --> uruchamia walidację 
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var validationResult = _validator.Validate(dto);
            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult);
            //}

            var id = _roomService.Create(dto);

            _logger.LogDebug($"Utworzono nowy pokój z id = {id}");
            var actionName = nameof(Get);
            var routeValues = new { id };
            return CreatedAtAction(actionName, routeValues, null);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            _roomService.Delete(id);
            _logger.LogDebug($"Usunieto pokój z id = {id}");
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateRoomDto dto)
        {
            if (id != dto.RoomId)
            {
                throw new BadRequestException("Id param is not valid");
            }

            _roomService.Update(dto);
            _logger.LogDebug($"Zaktualizowano pokój z id = {id}");
            return NoContent();
        }



    }
}
