using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.SharedKernel.Dto.Room;

namespace ConferenceBooking.Application.Validators.Room
{
    public class RegisterCreateRoomDtoValidator : AbstractValidator<CreateRoomDto>
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

            RuleFor(s => s.RoomId)
                .Custom((value, context) =>
                {
                    bool inUse = unitOfWork.RoomRepository.RoomExists(value);
                    if (inUse)
                    {
                        context.AddFailure("Room", $"Room of id {value} doesnt exist");
                    }
                });
        }
    }
}
