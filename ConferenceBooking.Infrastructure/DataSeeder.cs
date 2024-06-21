using ConferenceBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Infrastructure
{
    public class DataSeeder
    {

        private readonly ConferenceDbContext _dbContext;
        public DataSeeder(ConferenceDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Seed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Rooms.Any())
                {

                    // Dodawanie użytkowników
                    var user1 = new User { Name = "John Doe", Email = "john.doe@example.com", Password = "password123" };
                    var user2 = new User { Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password456" };
                    _dbContext.Users.AddRange(user1, user2);

                    // Dodawanie sal konferencyjnych
                    var room1 = new Room { RoomName = "Conference Room A", Location = "1st Floor", Capacity = 20 };
                    var room2 = new Room { RoomName = "Conference Room B", Location = "2nd Floor", Capacity = 30 };
                    _dbContext.Rooms.AddRange(room1, room2);

                    // Dodawanie wyposażenia
                    var equipment1 = new Equipment { Room = room1, EquipmentName = "Projector", Quantity = 1 };
                    var equipment2 = new Equipment { Room = room1, EquipmentName = "Whiteboard", Quantity = 1 };
                    var equipment3 = new Equipment { Room = room2, EquipmentName = "Projector", Quantity = 2 };
                    _dbContext.Equipments.AddRange(equipment1, equipment2, equipment3);

                    // Dodawanie dostępności sal
                    var availability1 = new RoomAvailability { Room = room1, AvailableDate = DateTime.Now.AddDays(1), IsAvailable = true };
                    var availability2 = new RoomAvailability { Room = room2, AvailableDate = DateTime.Now.AddDays(2), IsAvailable = true };
                    _dbContext.RoomAvailabilities.AddRange(availability1, availability2);

                    // Dodawanie rezerwacji
                    var booking1 = new Booking { User = user1, Room = room1, StartTime = DateTime.Now.AddDays(1).AddHours(9), EndTime = DateTime.Now.AddDays(1).AddHours(11) };
                    var booking2 = new Booking { User = user2, Room = room2, StartTime = DateTime.Now.AddDays(2).AddHours(10), EndTime = DateTime.Now.AddDays(2).AddHours(12) };
                    _dbContext.Bookings.AddRange(booking1, booking2);

                    _dbContext.SaveChanges();




                }
            }
        }
    }
}
