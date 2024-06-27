using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.SharedKernel.Dto.Equipment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Validators.Equipment
{
    public class RegisterUpdateEquipmentDtoValidator: AbstractValidator<UpdateEquipmentDto>
    {
        public RegisterUpdateEquipmentDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.EquipmentName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);



            RuleFor(p => p.RoomId)
                .Custom((value, context) =>
                {
                    bool exists = unitOfWork.RoomRepository.RoomExists(value);
                    if (!exists)
                    {
                        context.AddFailure("RoomId", $"Room of id {value} does not exist");
                    }
                });
        }
    }
}
