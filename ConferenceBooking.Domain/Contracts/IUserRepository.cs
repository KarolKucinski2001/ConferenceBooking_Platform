using ConferenceBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Contracts
{
    public interface IUserRepository: IRepository<User>
    {
        public List<User> GetAll();
        public User Get(int id);
        public bool UserExists(int id);
    }
}
