using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceBooking.Domain.Models;

namespace ConferenceBooking.Domain.Contracts
{
    // interfejsy repozytoriów specyficznych
    public interface IRoomRepository : IRepository<Room>
    {
        int GetMaxId();
        bool IsInUse(string email);
    }
}
