using FluentAssertions;
using Insurance.Api.Controllers;
using Insurance.Data.Models;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Requests;
using Insurance.Domain.Tests.Entity;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Insurance.Api.Tests.ControllerTests
{
    public class SurchargeControllerTest : IClassFixture<ControllerTestFixture>
    {
        private readonly SurchargeController _surchargeController;

        public SurchargeControllerTest(ControllerTestFixture fixture)
        {
            var surchargeService = fixture.ServiceProvider.GetService<ISurchargeService>();
            _surchargeController = new SurchargeController(surchargeService);
        }

        [Fact]
        public void GetSurchargeRateByProductId()
        {
            // Arrange
            var expected = new TestSurchargeRate1();
            var request = new SurchargeRateRequestQuery
            {
                ProductTypeId = 1
            };

            // Act
            var actual = _surchargeController.Get(request);

            // Assert
            actual.Result.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void AddSurchargeRate()
        {
            // Arrange
            var request = new SurchargeRateRequestPut
            {
                SurchargeRate = new SurchargeRate
                {
                    ProductTypeId = 1,
                    SurchargeAmount = 100
                }
            };

            // Act
            var actual = _surchargeController.Put(request);

            // Assert
            actual.Result.Value.Should().Be(true);
        }
    }
}