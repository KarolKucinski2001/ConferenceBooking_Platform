using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.SharedKernel.Dto.Booking;
using ConferenceBooking.SharedKernel.Dto.Room;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Validators.Booking
{
    public  class RegisterCreateBookingDtoValidator : AbstractValidator<CreateBookingDto>
    {

        public RegisterCreateBookingDtoValidator(IUnitOfWork unitOfWork)
        {

            //RuleFor(p => DateOnly.FromDateTime(p.StartTime))
            //    .InclusiveBetween(DateOnly.FromDateTime(DateTime.Today.AddDays(1)), DateOnly.FromDateTime(DateTime.Today.AddDays(365)));

            //RuleFor(p => DateOnly.FromDateTime(p.EndTime))
            //   .InclusiveBetween(DateOnly.FromDateTime(DateTime.Today.AddDays(1)), DateOnly.FromDateTime(DateTime.Today.AddDays(365 + _max_days)));



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
