using FluentAssertions;
using Insurance.Api.Controllers;
using Insurance.Api.ViewModels;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Requests;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace Insurance.Api.Tests.ControllerTests
{
    public class InsuranceControllerTest : IClassFixture<ControllerTestFixture>
    {
        private readonly InsuranceController _insuranceController;

        public InsuranceControllerTest(ControllerTestFixture fixture)
        {
            var insuranceService = fixture.ServiceProvider.GetService<IInsuranceService>();
            _insuranceController = new InsuranceController(insuranceService);
        }

        [Fact]
        public void GetInsuranceValueByProductId()
        {
            // Arrange
            var expected = new InsuranceDto { ProductId = 1, InsuranceValue = 1000 };

            // Act
            var actual = _insuranceController.Get(new ViewModels.InsuranceDto { ProductId = 1 });

            // Assert
            actual.Result.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetInsuranceValueByOrder()
        {
            // Arrange
            var expected = new OrderInsuranceResponse(1000);
            var request = new OrderInsuranceRequestQuery
            {
                Products = new List<int>() { 1, 2 }
            };

            // Act
            var actual = _insuranceController.Get(request);

            // Assert
            actual.Result.Value.Should().BeEquivalentTo(expected);
        }
    }
}