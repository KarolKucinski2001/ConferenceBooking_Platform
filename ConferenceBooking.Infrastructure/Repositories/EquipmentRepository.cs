using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Infrastructure.Repositories
{
    public class EquipmentRepository:Repository<Equipment>, IEquipmentRepository
    {
        private readonly ConferenceDbContext _conferenceDbContext;

        public EquipmentRepository(ConferenceDbContext context)
            : base(context)
        {
            _conferenceDbContext = context;
        }

        public List<Equipment> GetAll()
        {
            return _conferenceDbContext.Equipments.ToList();
        }

        public Equipment Get(int id)
        {
            var booking = _conferenceDbContext.Equipments
                .Include(o => o.Room)
                .Where(o => o.EquipmentId == id)
                .FirstOrDefault();

            return booking;
        }
        public bool EquipmentExists(int id)
        {
            var result = _conferenceDbContext.Equipments.Any(x => x.EquipmentId == id);
            return result;
        }
    }
}
