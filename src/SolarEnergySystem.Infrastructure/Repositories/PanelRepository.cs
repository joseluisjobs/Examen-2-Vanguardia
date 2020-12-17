using System.Collections.Generic;
using System.Linq;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;

namespace SolarEnergySystem.Infrastructure.Repositories
{
    public class PanelRepository : EntityFrameworkRepository<Panel,string>, IPanelRepository
    {
        private readonly SolarEnergySystemDatabaseContext _solarEnergySystemDbContext;

        public PanelRepository(SolarEnergySystemDatabaseContext solarEnergySystemDbContext):base(solarEnergySystemDbContext)
        {
            _solarEnergySystemDbContext = solarEnergySystemDbContext;
        }

        public IEnumerable<Panel> GetAllOrderByType()
        {
            return _solarEnergySystemDbContext.Panel.OrderBy(x => x.PanelType).ToList();
        }
       

        
    }
}