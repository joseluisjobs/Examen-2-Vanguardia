using System.Collections.Generic;
using System.Linq;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Enums;
using SolarEnergySystem.Core.Interfaces;

namespace SolarEnergySystem.UnitTests.Fakes
{
    public class FakePanelRepository : IPanelRepository
    {
        private readonly IEnumerable<Panel> _panels;

        public FakePanelRepository()
        {
            _panels =  new List<Panel>
            {
               new Panel {
                    PanelType= 0,
                    Longitude= 450.93,
                    Latitude = -3850.04,
                    Brand =  "Brand1",
                    MeasuringUnit = 0,
                    Id = "A305V5"
                }
            };


        }
        public IEnumerable<Panel> GetAllOrderByType()
        {
            return _panels.Select(x => x).ToList();
        }
    }
}