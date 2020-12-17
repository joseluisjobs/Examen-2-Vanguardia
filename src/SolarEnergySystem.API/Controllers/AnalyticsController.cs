using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Enums;
using SolarEnergySystem.Core.Interfaces;
using SolarEnergySystem.Infrastructure;

namespace SolarEnergySystem.API.Controllers
{
    [ApiController]
    [Route("panels")]
    public class AnalyticsController : ControllerBase
    {
        

        private IElectricityReadingService _electricityReadingService;
        public AnalyticsController(IElectricityReadingService electricityReadingService)
        {
            _electricityReadingService = electricityReadingService;
        }

        public ActionResult<ElectricityReading> Post([FromBody] ElectricityReading reading)
        {
            var serviceResult = _electricityReadingService.AddReading(reading.PanelId, reading.KiloWatt);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);
            var result = new ElectricityReading
            {
                KiloWatt = serviceResult.Result.KiloWatt,
                ReadingDateTime = serviceResult.Result.ReadingDateTime,
                PanelId = reading.PanelId
            };
            return Ok(result);
        }


    }
}
