using System.Collections;
using System.Collections.Generic;
using SolarEnergySystem.Core.Entities;

namespace SolarEnergySystem.Core.Interfaces
{
    public interface IElectricityReadingRepository
    {
        ElectricityReading GetReadingById(string panelId);
    }
}