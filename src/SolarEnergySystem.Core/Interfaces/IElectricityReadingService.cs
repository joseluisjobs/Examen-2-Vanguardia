using SolarEnergySystem.Core.Entities;

namespace SolarEnergySystem.Core.Interfaces
{
    public interface IElectricityReadingService
    {
        ServiceResult<ElectricityReading> AddReading(string panelId, double energy);
    }
}