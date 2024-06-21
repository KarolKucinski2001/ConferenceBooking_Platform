using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Domain.Models;


namespace ConferenceBooking.Infrastructure.Repositories
{
    public class RoomRepository: Repository<Room>, IRoomRepository
    {
        private readonly ConferenceDbContext _conferenceDbContext;

        public RoomRepository(ConferenceDbContext context)
            : base(context)
        {
            _conferenceDbContext = context;
        }

        public int GetMaxId()
        {
            return _conferenceDbContext.Rooms.Max(x => x.RoomId);
        }

        public bool IsInUse(string name)
        {
            var result = _conferenceDbContext.Rooms.Any(x => x.RoomName == name);
            return result;
        }

    }
}
