using AutoMapper;
using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Domain.Exceptions;
using ConferenceBooking.Domain.Models;
using ConferenceBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(BookingDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Order is null");
            }

            var id = _uow.BookingRepository.GetMaxId() + 1;
            var booking = _mapper.Map<Booking>(dto);
            booking.BookingId = id;

            _uow.BookingRepository.Insert(booking);
            _uow.Save();

            return id;
        }

        public List<BookingDto> GetAll()
        {
            var bookings = _uow.BookingRepository.GetAll();

            List<BookingDto> result = _mapper.Map<List<BookingDto>>(bookings);
            return result;
        }

        public BookingDto GetByIdWithDetails(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var booking = _uow.BookingRepository.GetByIdWithDetails(id);
            if (booking == null)
            {
                throw new NotFoundException("Order not found");
            }

            var result = _mapper.Map<BookingDto>(booking);
            return result;
        }
    }

    
}


