using ConferenceBooking.Domain.Models;
using ConferenceBooking.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceBooking.Infrastructure.Repositories;

namespace ConferenceBooking.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ConferenceDbContext _context;
        public IBookingRepository BookingRepository { get; }
        public IRoomRepository RoomRepository { get; }  
        public IUserRepository UserRepository { get; }
        public IEquipmentRepository EquipmentRepository { get; }    

     
        public IRepository<RoomAvailability> RoomAvailabilities { get; private set; }

        public UnitOfWork(ConferenceDbContext context,IRoomRepository roomRepository, IBookingRepository bookingRepository, IUserRepository userRepository, IEquipmentRepository equipmentRepository)
        {
            this._context = context;

            this.BookingRepository = bookingRepository;
            this.RoomRepository = roomRepository;
            this.UserRepository =userRepository;
            this.EquipmentRepository = equipmentRepository;

         
            RoomAvailabilities = new Repository<RoomAvailability>(_context);
        }

        

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
