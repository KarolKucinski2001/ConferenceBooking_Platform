using ConferenceBooking.SharedKernel.Dto.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Application.Services.Interfaces
{
    public interface IEquipmentService
    {
        List<EquipmentDto> GetAll();
        EquipmentDto GetById(int id);
        int Create(CreateEquipmentDto dto);
        void Update(UpdateEquipmentDto dto);
        void Delete(int id);
    }
}
