using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolarEnergySystem.Core.DTO;
using SolarEnergySystem.Core.Enums;
using SolarEnergySystem.Core.Interfaces;
using SolarEnergySystem.Infrastructure;

namespace SolarEnergySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanelsController : ControllerBase
    {

        private readonly IPanelService _panelService;

        public PanelsController(IPanelService panelService)
        {
            _panelService = panelService;
        }

        [HttpGet]
        public ActionResult<PanelDTO> Get()
        {
            var serviceResult = _panelService.GetAllOrderByType();

            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);
            var panels = serviceResult.Result;

            return Ok(panels.Select( p => new PanelDTO()
            {
                Id= p.Id,
                MeasuringUnit = p.MeasuringUnit,
                PanelType = p.PanelType
            }));
        }

    }
}
