﻿using ConferenceBooking.SharedKernel.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        int Create(CreateUserDto dto);
        void Update(UpdateUserDto dto);
        void Delete(int id);
    }
}
