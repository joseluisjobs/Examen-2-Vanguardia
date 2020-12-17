using System.Collections.Generic;
using System.Linq;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;

namespace SolarEnergySystem.Infrastructure.Repositories
{
    public class ElectricityReadingRepository : EntityFrameworkRepository<ElectricityReading, int>, IElectricityReadingRepository
    {
        private readonly SolarEnergySystemDatabaseContext _solarEnergySystemDbContext;
        public ElectricityReadingRepository(SolarEnergySystemDatabaseContext context) : base(context)
        {
            _solarEnergySystemDbContext = context;
        }

        public ElectricityReading GetReadingById(string panelId)
        {
            return _solarEnergySystemDbContext.ElectricityReading.OrderByDescending(x => x.ReadingDateTime).FirstOrDefault();
        }
    }
}