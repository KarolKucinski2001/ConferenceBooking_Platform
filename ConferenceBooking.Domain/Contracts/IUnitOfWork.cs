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
        IEquipmentRepository EquipmentRepository { get; }   
        IUserRepository UserRepository{ get; }
      //  IRepository<Room> Rooms { get; }
      //  IRepository<Booking> Bookings { get; }
      //  IRepository<Equipment> Equipments { get; }
        IRepository<RoomAvailability> RoomAvailabilities { get; }

        void Save();
    }
}
