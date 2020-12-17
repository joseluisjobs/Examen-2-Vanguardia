using SolarEnergySystem.Core.Enums;
using SolarEnergySystem.Core.Services;
using SolarEnergySystem.UnitTests.Fakes;
using Xunit;

namespace SolarEnergySystem.UnitTests
{
    public class PanelServiceTest
    {
        private PanelServices GetPanelService()
        {
            return new PanelServices(new FakePanelRepository());
        }

        [Fact]
        public void GetAllOrderByType_Success()
        {
            var service = GetPanelService();

            var result = service.GetAllOrderByType();

            Assert.True(result.ResponseCode == ResponseCode.Success);
            Assert.NotNull(result.Result);
        }
    }
}