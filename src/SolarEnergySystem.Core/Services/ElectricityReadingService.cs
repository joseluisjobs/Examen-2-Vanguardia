using System;
using System.ComponentModel.DataAnnotations;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Enums;
using SolarEnergySystem.Core.Interfaces;

namespace SolarEnergySystem.Core.Services
{
    public class ElectricityReadingService : IElectricityReadingService
    {
        private readonly IElectricityReadingRepository _electricityReadingRepository;
        private readonly IRepository<Panel, string> _panelRepository;

        public ElectricityReadingService(IElectricityReadingRepository electricityReadingRepository, IRepository<Panel, string> panelRepository)
        {
            _electricityReadingRepository = electricityReadingRepository;
            _panelRepository = panelRepository;
        }
        public ServiceResult<ElectricityReading> AddReading(string panelId, double energy)
        {
            if (energy <= 0)
                return ServiceResult<ElectricityReading>.ErrorResult("No se aceptan valores menores o iguales a 0");
            var panel = _panelRepository.GetById(panelId);
            if(panel == null) return ServiceResult<ElectricityReading>.ErrorResult("Panel no existe");
            var date = DateTime.UtcNow;
            var lastReading = _electricityReadingRepository.GetReadingById(panelId);
            var value = panel.MeasuringUnit == MeasuringUnit.KiloWatt ? energy : energy * 1000;
            switch (panel.PanelType)
            {
                case PanelType.Regular:
                {
                        var hours = lastReading == null ? 1 : (date - lastReading.ReadingDateTime).TotalHours;
                        if (hours  < 1) return ServiceResult<ElectricityReading>.ErrorResult("El registro es cada hora!");
                        var newReading = new ElectricityReading()
                        {
                            KiloWatt = value,
                            PanelId = panelId,
                            ReadingDateTime = date
                        };
                        AddReading(panel, newReading);
                        return ServiceResult<ElectricityReading>.SuccessResult(newReading);
                }
                case PanelType.Limited:
                {
                    var days = lastReading == null ? 1 : (date - lastReading.ReadingDateTime).Days;
                    if (days < 1) return ServiceResult<ElectricityReading>.ErrorResult("El registro es cada dia!");
                    var newReading = new ElectricityReading()
                    {
                        KiloWatt = value,
                        PanelId = panelId,
                        ReadingDateTime = date
                    };
                    AddReading(panel, newReading);
                    return ServiceResult<ElectricityReading>.SuccessResult(newReading);
                }
                case PanelType.Ultimate:
                {
                    var minutes = lastReading == null ? 1 : (date - lastReading.ReadingDateTime).Minutes;
                    if (minutes < 1) return ServiceResult<ElectricityReading>.ErrorResult("El registro es cada minuto!");
                    var newReading = new ElectricityReading()
                    {
                        KiloWatt = value,
                        PanelId = panelId,
                        ReadingDateTime = date
                    };
                    AddReading(panel, newReading);
                    return ServiceResult<ElectricityReading>.SuccessResult(newReading);
                }
                default: return ServiceResult<ElectricityReading>.ErrorResult("Panel no exite");
            }

        }

       
        public void AddReading(Panel panel, ElectricityReading reading)
        {
            panel.ElectricityReadings.Add(reading);
        }
    }
}