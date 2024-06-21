using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceBooking.SharedKernel.Dto;
using ConferenceBooking.Domain.Contracts;

namespace ConferenceBooking.Application.Validators
{
    public class RegisterCreateRoomDtoValidator: AbstractValidator<CreateRoomDto>
    {

        public RegisterCreateRoomDtoValidator(IUnitOfWork unitOfWork)
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

            RuleFor(s => s.RoomName)
                .Custom((value, context) =>
                {
                    bool inUse = unitOfWork.RoomRepository.IsInUse(value);
                    if (inUse)
                    {
                        context.AddFailure("Name", "Room name is in use");
                    }
                });
        }
    }
}
