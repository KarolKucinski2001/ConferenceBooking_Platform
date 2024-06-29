using ConferenceBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Infrastructure
{
    public class ConferenceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<RoomAvailability> RoomAvailabilities { get; set; }



        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options)
                : base(options)
        {
        }
        //    // Database.EnsureCreated() sprawdza, czy baza danych istnieje.  
        //    // Jeśli tak - nic nie robi.  
        //    // Jeśli nie - tworzy bazę i tabele zgodnie z modelem. 
        //    // UWAGA: Gdy baza istnieje, nie jest sprawdzane, czy jest zgodna z modelem. 
        //    // Aby zagwarantować zgodność bazy z modelem, można rozważyć sekwencję instrukcji:  
        //    //      
        //    //      

        //    //Database.EnsureDeleted();
        //    //Database.EnsureCreated();
        //    // Powoduje to jednak zawsze usuwanie bazy przed rozpoczęciem działania programu. 
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Konfiguracja SQLite jako dostawcy bazy danych
            optionsBuilder.UseSqlite("Data Source=conference.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            //modelBuilder.Entity<RoomAvailability>()
            //    .HasKey(ra => ra.AvailabilityId);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Bookings)
            //    .WithOne(b => b.User)
            //    .HasForeignKey(b => b.UserId);

            //modelBuilder.Entity<Room>()
            //    .HasMany(r => r.Bookings)
            //    .WithOne(b => b.Room)
            //    .HasForeignKey(b => b.RoomId);

            //modelBuilder.Entity<Room>()
            //    .HasMany(r => r.Equipments)
            //    .WithOne(e => e.Room)
            //    .HasForeignKey(e => e.RoomId);

            //modelBuilder.Entity<Room>()
            //    .HasMany(r => r.RoomAvailabilities)
            //    .WithOne(ra => ra.Room)
            //    .HasForeignKey(ra => ra.RoomId);

            //// Usuń następujący kod, który powoduje błąd CS0029
            //// modelBuilder.Entity<RoomAvailability>()
            ////     .HasMany(ra => ra.Bookings)
            ////     .WithOne(b => b.Room)
            ////     .HasForeignKey(b => b.RoomId);

            //// Popraw konfigurację relacji Booking -> Room
            //modelBuilder.Entity<Booking>()
            //    .HasOne(b => b.Room)
            //    .WithMany(r => r.Bookings)
            //    .HasForeignKey(b => b.RoomId);
        }

    }
}

