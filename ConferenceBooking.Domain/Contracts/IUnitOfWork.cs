using ConferenceBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRoomRepository RoomRepository { get; }
        IBookingRepository BookingRepository { get; }   
        IRepository<User> Users { get; }
      //  IRepository<Room> Rooms { get; }
      //  IRepository<Booking> Bookings { get; }
        IRepository<Equipment> Equipments { get; }
        IRepository<RoomAvailability> RoomAvailabilities { get; }

        void Save();
    }
}
