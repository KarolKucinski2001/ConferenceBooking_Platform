using AutoMapper;
using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Domain.Exceptions;
using ConferenceBooking.Domain.Models;
using ConferenceBooking.SharedKernel.Dto.Booking;
using ConferenceBooking.SharedKernel.Dto.Equipment;
using ConferenceBooking.SharedKernel.Dto.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services.Generic
{
    public class EquipmentService:IEquipmentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public int Create(CreateEquipmentDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Booking is null");
            }

            //var id = _uow.BookingRepository.GetMaxId() + 1;
            //var booking = _mapper.Map<Booking>(dto);
            //booking.BookingId = id;

            var equipment = _mapper.Map<Equipment>(dto);
            _uow.EquipmentRepository.Insert(equipment);



            return equipment.EquipmentId;
        }

        public void Delete(int id)
        {
            var eq = _uow.EquipmentRepository.Get(id);

            if (eq == null)
            {
                throw new NotFoundException("Equipment not found");
            }

            _uow.BookingRepository.Delete(eq);
            _uow.Save();
        }

        public List<EquipmentDto> GetAll()
        {
            var eq = _uow.EquipmentRepository.GetAll();

            List<EquipmentDto> result = _mapper.Map<List<EquipmentDto>>(eq);
            return result;
        }

        public EquipmentDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var eq = _uow.EquipmentRepository.Get(id);
            if (eq == null)
            {
                throw new NotFoundException("Order not found");
            }

            var result = _mapper.Map<EquipmentDto>(eq);
            return result;
        }



        public void Update(UpdateEquipmentDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No data to update");
            }

            var eq = _uow.EquipmentRepository.Get(dto.EquipmentId);
            if (
                eq== null)
            {
                throw new NotFoundException($"Equipment with id {dto.EquipmentId} was not found");
            }

            eq.RoomId = dto.RoomId;
            eq.EquipmentId = dto.EquipmentId;
            eq.EquipmentName = dto.EquipmentName;
            eq.Quantity = dto.Quantity;


        }
    }
}
