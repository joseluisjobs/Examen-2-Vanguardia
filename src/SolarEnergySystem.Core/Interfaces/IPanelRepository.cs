using System.Collections.Generic;
using SolarEnergySystem.Core.Entities;

namespace SolarEnergySystem.Core.Interfaces
{
    public interface IPanelRepository
    {
        IEnumerable<Panel> GetAllOrderByType();
    }
}