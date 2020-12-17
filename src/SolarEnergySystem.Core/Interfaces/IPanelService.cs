using System.Collections.Generic;
using SolarEnergySystem.Core.Entities;

namespace SolarEnergySystem.Core.Interfaces
{
    public interface IPanelService
    {
        ServiceResult<IEnumerable<Panel>> GetAll();

        ServiceResult<IEnumerable<Panel>> GetAllOrderByType();

    }
}