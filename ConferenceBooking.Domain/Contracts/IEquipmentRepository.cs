using ConferenceBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Contracts
{
    public interface IEquipmentRepository:IRepository<Equipment>
    {
        public List<Equipment> GetAll();
        public Equipment Get(int id);
        public bool EquipmentExists(int id);
    }
}
