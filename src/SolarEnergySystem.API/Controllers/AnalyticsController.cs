using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolarEnergySystem.Infrastructure;

namespace SolarEnergySystem.API.Controllers
{
    [ApiController]
    [Route("panels")]
    public class AnalyticsController : ControllerBase
    {
        private readonly SolarEnergySystemDatabaseContext _context;

        public AnalyticsController(SolarEnergySystemDatabaseContext context)
        {
            _context = context;
        }

        [Route("{panelId}/analytics")]
        public IActionResult Get(string panelId)
        {
            return Ok(_context.ElectricityReading.Where(x => x.PanelId == panelId));
        }
    }
}
