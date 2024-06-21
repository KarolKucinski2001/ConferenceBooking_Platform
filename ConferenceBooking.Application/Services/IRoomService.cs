using ConferenceBooking.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services
{
    public interface IRoomService
    {
        List<RoomDto> GetAll();
        RoomDto GetById(int id);
        int Create(CreateRoomDto dto);
        void Update(UpdateRoomDto dto);
        void Delete(int id);
    }
}
