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
        public IRepository<User> Users { get; private set; }
       // public IRepository<Room> Rooms { get; private set; }
      //  public IRepository<Booking> Bookings { get; private set; }
        public IRepository<Equipment> Equipments { get; private set; }
        public IRepository<RoomAvailability> RoomAvailabilities { get; private set; }

        public UnitOfWork(ConferenceDbContext context,IRoomRepository roomRepository, IBookingRepository bookingRepository)
        {
            _context = context;

            this.BookingRepository = bookingRepository;
            this.RoomRepository = roomRepository;

            Users = new Repository<User>(_context);
           // Rooms = new Repository<Room>(_context);
           // Bookings = new Repository<Booking>(_context);
            Equipments = new Repository<Equipment>(_context);
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
