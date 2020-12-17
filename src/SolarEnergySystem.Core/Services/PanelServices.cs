using System.Collections.Generic;
using System.Linq;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;

namespace SolarEnergySystem.Core.Services
{
    public class PanelServices : IPanelService
    {
        private readonly IPanelRepository _panelRepository;

        public PanelServices(IPanelRepository panelRepository)
        {
            _panelRepository = panelRepository;
        }
        public ServiceResult<IEnumerable<Panel>> GetAll()
        {
            var panels = _panelRepository.GetAllOrderByType();
            return ServiceResult<IEnumerable<Panel>>.SuccessResult(panels);
        }

        public ServiceResult<IEnumerable<Panel>> GetAllOrderByType()
        {
            var panels = _panelRepository.GetAllOrderByType();
            return ServiceResult<IEnumerable<Panel>>.SuccessResult(panels);
        }
    }
}