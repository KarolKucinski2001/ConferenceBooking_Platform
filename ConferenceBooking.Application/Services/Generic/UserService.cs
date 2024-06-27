using AutoMapper;
using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Domain.Exceptions;
using ConferenceBooking.Domain.Models;
using ConferenceBooking.SharedKernel.Dto.Room;
using ConferenceBooking.SharedKernel.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services.Generic
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public int Create(CreateUserDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("User is null");
            }


            var user = _mapper.Map<User>(dto);


            //// set default image url if user did not souuport its own
            //room.ImageUrl = string.IsNullOrEmpty(dto.ImageUrl)
            //    ? "/images/no-image-icon.png"
            //    : dto.ImageUrl;

            _uow.UserRepository.Insert(user);
            _uow.Save();

            return user.UserId;
        }

        public void Delete(int id)
        {
            var user = _uow.UserRepository.Get(id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            _uow.UserRepository.Delete(user);
            _uow.Save();
        }

        public List<UserDto> GetAll()
        {
            var users = _uow.UserRepository.GetAll();

            List<UserDto> result = _mapper.Map<List<UserDto>>(users);
            return result;
        }

        public UserDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var user = _uow.UserRepository.Get(id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public void Update(UpdateUserDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No user data");
            }

            var user = _uow.UserRepository.Get(dto.UserId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            user.Name = dto.Name;
            user.Password = dto.Password;
            user.Email = dto.Email;
            //room.RoomAvailabilities = dto.RoomAvailabilities;
            //room.Equipments = dto.Equipments;


            //// set default image url if user did not souuport its own
            //room.ImageUrl = string.IsNullOrEmpty(dto.ImageUrl)
            //    ? "/images/no-image-icon.png"
            //    : dto.ImageUrl;

            _uow.Save();
        }
    }
}
