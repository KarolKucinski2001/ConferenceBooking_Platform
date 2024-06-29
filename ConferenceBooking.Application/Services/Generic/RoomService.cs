using AutoMapper;
using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Domain.Exceptions;
using ConferenceBooking.Domain.Models;
using ConferenceBooking.SharedKernel.Dto.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services.Generic
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public int Create(CreateRoomDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Room is null");
            }

         
           var room = _mapper.Map<Room>(dto);
           

            //// set default image url if user did not souuport its own
            //room.ImageUrl = string.IsNullOrEmpty(dto.ImageUrl)
            //    ? "/images/no-image-icon.png"
            //    : dto.ImageUrl;

            _uow.RoomRepository.Insert(room);
            _uow.Save();

            return room.RoomId;
        }

        public void Delete(int id)
        {
            var product = _uow.RoomRepository.Get(id);
            if (product == null)
            {
                throw new NotFoundException("Room not found");
            }

            _uow.RoomRepository.Delete(product);
            _uow.Save();
        }

        public List<RoomDto> GetAll()
        {
            var rooms = _uow.RoomRepository.GetAll();

            List<RoomDto> result = _mapper.Map<List<RoomDto>>(rooms);
            return result;
        }

        public RoomDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var room = _uow.RoomRepository.Get(id);
            if (room == null)
            {
                throw new NotFoundException("Room not found");
            }

            var result = _mapper.Map<RoomDto>(room);
            return result;
        }

        public void Update(UpdateRoomDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No room data");
            }

            var room = _uow.RoomRepository.Get(dto.RoomId);
            if (room == null)
            {
                throw new NotFoundException("Room not found");
            }

            room.RoomName = dto.RoomName;
            room.Capacity = dto.Capacity;
            room.Location = dto.Location;
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
