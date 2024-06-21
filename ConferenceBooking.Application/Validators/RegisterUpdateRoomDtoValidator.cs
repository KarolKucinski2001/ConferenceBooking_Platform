using ConferenceBooking.SharedKernel.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Validators
{
    public class RegisterUpdateRoomDtoValidator: AbstractValidator<UpdateRoomDto>
    {
        public RegisterUpdateRoomDtoValidator()
        {
            RuleFor(p => p.RoomName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(p => p.Location)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(p => p.Capacity)
                .GreaterThan(0);


        }
    }
}
