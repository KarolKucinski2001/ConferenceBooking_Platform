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

        public List<Room> GetAll()
        {
            return _conferenceDbContext.Rooms.ToList();
        }

        public int Get(int id)
        {
            return _conferenceDbContext.Rooms.Max(x => x.RoomId);
        }

        public bool RoomExists(int id)
        {
            var result = _conferenceDbContext.Rooms.Any(x => x.RoomId == id);
            return result;
        }

    }
}
