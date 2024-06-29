using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.Domain.Exceptions;
using ConferenceBooking.SharedKernel.Dto.Booking;
using ConferenceBooking.SharedKernel.Dto.Equipment;
using ConferenceBooking.SharedKernel.Dto.Room;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceBooking.WebAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController:Controller
    {

            private readonly IEquipmentService _equipmentService;
            private readonly ILogger<EquipmentController> _logger;

            public EquipmentController(IEquipmentService equipmentService, ILogger<EquipmentController> logger)
            {
                this._equipmentService = equipmentService;
                _logger = logger;
            }

            [HttpGet("all")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public ActionResult<IEnumerable<EquipmentDto>> GetAll()
            {
                var result = _equipmentService.GetAll();
                _logger.LogDebug("Pulled a list of all Equipments");
                return Ok(result);
            }


            [HttpGet("{id}", Name = "GetEquipment")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<EquipmentDto> Get(int id)
            {
                var result = _equipmentService.GetById(id);
                _logger.LogDebug($"Pulled an equpment with id = {id}");
                return Ok(result);
            }

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult Create([FromBody] CreateEquipmentDto dto)
            {
                var id = _equipmentService.Create(dto);
                _logger.LogDebug($"Created new equipment with id = {id}");
                var actionName = nameof(Get);
                var routeValues = new { id };
                return CreatedAtAction(actionName, routeValues, null);
            }



            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult Update(int id, [FromBody] UpdateEquipmentDto dto)
            {
                if (id != dto.EquipmentId)
                {
                    throw new BadRequestException("Id param is not valid");
                }

                _equipmentService.Update(dto);
                _logger.LogDebug($"Updated equimnets with id = {id}");
                return NoContent();
            }


            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult Delete(int id)
            {
                _equipmentService.Delete(id);
                _logger.LogDebug($"Deleted equipment with id = {id}");
                return NoContent();
            }
        }
}
