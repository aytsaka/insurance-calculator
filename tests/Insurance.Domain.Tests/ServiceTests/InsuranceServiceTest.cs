using FluentAssertions;
using Insurance.Data.Context;
using Insurance.Data.Models;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Requests;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Insurance.Domain.Tests.ServiceTests
{
    public class InsuranceServiceTest : IClassFixture<ServiceTestFixture>
    {
        private readonly IInsuranceService _insuranceService;
        private readonly InsuranceDbContext _context;

        public InsuranceServiceTest(ServiceTestFixture fixture)
        {
            _insuranceService = fixture.ServiceProvider.GetService<IInsuranceService>();
            _context = fixture.ServiceProvider.GetService<InsuranceDbContext>();
        }

        [Fact]
        public async Task TestGetInsuranceValueByProductIdAsync()
        {
            //Arrange
            var expected = 1000d;
            // Act
            var actual = await _insuranceService.GetInsuranceValueByProductIdAsync(1);
            //Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public async Task TestGetInsuranceValueByOrderAsync()
        {
            //Arrange
            var expected = 4500d;
            var request = new OrderInsuranceRequestQuery()
            {
                Products = new List<int>() { 1, 2 }
            };
            _context.SurchargeRates.Add(new SurchargeRate
            {
                ProductTypeId = 1,
                SurchargeAmount = 500
            });
            // Act
            var actual = await _insuranceService.GetInsuranceValueByOrderAsync(request);
            //Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public async Task TestGetInsuranceValueByOrderAsync_CanNotBeInsured()
        {
            //Arrange
            var expected = 0d;
            var request = new OrderInsuranceRequestQuery()
            {
                Products = new List<int>() { 3 }
            };
            // Act
            var actual = await _insuranceService.GetInsuranceValueByOrderAsync(request);
            //Assert
            actual.Should().Be(expected);
        }
    }
}
