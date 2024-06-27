using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.SharedKernel.Dto.Booking;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Validators.Booking
{
    public class RegisterUpdateBookingDtoValidator: AbstractValidator<UpdateBookingDto>
    {
        public RegisterUpdateBookingDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.UserId)
              .Custom((value, context) =>
              {
                  bool exists = unitOfWork.UserRepository.UserExists(value);
                  if (!exists)
                  {
                      context.AddFailure("userId", $"User of id {value} does not exist");
                  }
              });

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
