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
    public class UserRepository :Repository<User>, IUserRepository
    {
        private readonly ConferenceDbContext _conferenceDbContext;

        public UserRepository(ConferenceDbContext context)
            : base(context)
        {
            _conferenceDbContext = context;
        }

        public List<User> GetAll()
        {
            return _conferenceDbContext.Users.ToList();
        }

        public User Get(int id)
        {
            var user = _conferenceDbContext.Users
                .Where(o => o.UserId == id)
                .FirstOrDefault();

            return user;
        }
        public bool UserExists(int id)
        {
            var result = _conferenceDbContext.Users.Any(x => x.UserId == id);
            return result;
        }

    }
}
