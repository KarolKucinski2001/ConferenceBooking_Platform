using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.SharedKernel.Dto.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Validators.User
{
    public class RegisterUpdateUserDtoValidator:  AbstractValidator<UpdateUserDto>
    {
        public RegisterUpdateUserDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(p => p.Password)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);


        }
    }
}
