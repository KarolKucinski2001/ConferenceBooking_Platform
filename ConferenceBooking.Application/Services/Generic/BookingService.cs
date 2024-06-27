using AutoMapper;
using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Domain.Exceptions;
using ConferenceBooking.Domain.Models;
using ConferenceBooking.SharedKernel.Dto.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services.Generic
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public int Create(CreateBookingDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Booking is null");
            }

            //var id = _uow.BookingRepository.GetMaxId() + 1;
            //var booking = _mapper.Map<Booking>(dto);
            //booking.BookingId = id;

            var booking = _mapper.Map<Booking>(dto);
            _uow.BookingRepository.Insert(booking);



            return booking.BookingId;
        }

        public void Delete(int id)
        {
            var booking = _uow.BookingRepository.Get(id);

            if (booking == null)
            {
                throw new NotFoundException("Offer not found");
            }

            _uow.BookingRepository.Delete(booking);
            _uow.Save();
        }

        public List<BookingDto> GetAll()
        {
            var bookings = _uow.BookingRepository.GetAll();

            List<BookingDto> result = _mapper.Map<List<BookingDto>>(bookings);
            return result;
        }

        public BookingDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var booking = _uow.BookingRepository.Get(id);
            if (booking == null)
            {
                throw new NotFoundException("Order not found");
            }

            var result = _mapper.Map<BookingDto>(booking);
            return result;
        }



        public void Update(UpdateBookingDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No data to update");
            }

            var booking = _uow.BookingRepository.Get(dto.BookingId);
            if (booking == null)
            {
                throw new NotFoundException($"Offer with id {dto.BookingId} was not found");
            }

            booking.RoomId = dto.RoomId;
            booking.UserId = dto.UserId;
            booking.EndTime = dto.EndTime;
            booking.StartTime = dto.StartTime;

            _uow.Save();

        }

    }
}


