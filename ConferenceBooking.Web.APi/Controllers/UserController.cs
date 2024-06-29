using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.Domain.Exceptions;
using ConferenceBooking.SharedKernel.Dto.Equipment;
using ConferenceBooking.SharedKernel.Dto.Room;
using ConferenceBooking.SharedKernel.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceBooking.WebAPi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
            private readonly IUserService _userService;
            private readonly ILogger<UserController> _logger;

            public UserController(IUserService userService, ILogger<UserController> logger)
            {
                this._userService = userService;
                _logger = logger;
            }

            [HttpGet("all")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public ActionResult<UserDto> GetAll()
            {
                var result = _userService.GetAll();
                _logger.LogDebug("Pulled a list of all Users");
                return Ok(result);
            }


            [HttpGet("{id}", Name = "GetUser")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<EquipmentDto> Get(int id)
            {
                var result = _userService.GetById(id);
                _logger.LogDebug($"Pulled a user with id = {id}");
                return Ok(result);
            }

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult Create([FromBody] CreateUserDto dto)
            {
                var id = _userService.Create(dto);
                _logger.LogDebug($"Created new user with id = {id}");
                var actionName = nameof(Get);
                var routeValues = new { id };
                return CreatedAtAction(actionName, routeValues, null);
            }



            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult Update(int id, [FromBody] UpdateUserDto dto)
            {
                if (id != dto.UserId)
                {
                    throw new BadRequestException("Id param is not valid");
                }

                _userService.Update(dto);
                _logger.LogDebug($"Updated user with id = {id}");
                return NoContent();
            }


            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult Delete(int id)
            {
                _userService.Delete(id);
                _logger.LogDebug($"Deleted user with id = {id}");
                return NoContent();
            }
        }
    }
