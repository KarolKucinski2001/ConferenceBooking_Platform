using AutoMapper;
using ConferenceBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceBooking.SharedKernel.Dto.User;
using ConferenceBooking.SharedKernel.Dto.RoomAvailability;
using ConferenceBooking.SharedKernel.Dto.Room;
using ConferenceBooking.SharedKernel.Dto.Equipment;
using ConferenceBooking.SharedKernel.Dto.Booking;

namespace ConferenceBooking.Application.Mappings
{
    public class ConferenceBookingMappingProfile:Profile
    {
        public ConferenceBookingMappingProfile()
        {
            CreateMap<BookingDto, Booking>().ReverseMap();
            CreateMap<RoomDto, Room>().ReverseMap();
            CreateMap<RoomAvailabilityDto, RoomAvailability>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<EquipmentDto, Equipment>().ReverseMap();

        }
    }
}
