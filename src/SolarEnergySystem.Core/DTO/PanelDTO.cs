using SolarEnergySystem.Core.Enums;

namespace SolarEnergySystem.Core.DTO
{
    public class PanelDTO
    {
        public PanelType PanelType { get; set; }
        
        public string Id { get; set; }

        public MeasuringUnit MeasuringUnit { get; set; }
    }
}