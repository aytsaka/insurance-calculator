using FluentAssertions;
using Insurance.Data.Context;
using Insurance.Data.Models;
using Insurance.Domain.Exceptions;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Requests;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Insurance.Domain.Tests.ServiceTests
{
    public class SurchargeServiceTest : IClassFixture<ServiceTestFixture>
    {
        private readonly ISurchargeService _surchargeService;
        private readonly InsuranceDbContext _context;

        public SurchargeServiceTest(ServiceTestFixture fixture)
        {
            _surchargeService = fixture.ServiceProvider.GetService<ISurchargeService>();
            _context = fixture.ServiceProvider.GetService<InsuranceDbContext>();
        }

        [Fact]
        public async Task TestAddSurchargeRateAsync()
        {
            //Arrange
            var expected = new SurchargeRate { ProductTypeId = 1, SurchargeAmount = 100 };
            var request = new SurchargeRateRequestPut
            {
                SurchargeRate = new SurchargeRate { ProductTypeId = 1, SurchargeAmount = 100 }
            };
            // Act
            await _surchargeService.AddSurchargeRateAsync(request);
            var actual = _surchargeService.GetByIdAsync(new SurchargeRateRequestQuery { ProductTypeId = 1 });
            //Assert
            actual.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TestUpdateSurchargeRateAsync()
        {
            //Arrange
            var expected = new SurchargeRate { ProductTypeId = 2, SurchargeAmount = 200 };
            var request = new SurchargeRateRequestPut
            {
                SurchargeRate = new SurchargeRate { ProductTypeId = 2, SurchargeAmount = 200 }
            };
            _context.SurchargeRates.Add(new SurchargeRate
            {
                ProductTypeId = 2,
                SurchargeAmount = 100
            });

            // Act
            await _surchargeService.AddSurchargeRateAsync(request);
            var actual = _surchargeService.GetByIdAsync(new SurchargeRateRequestQuery { ProductTypeId = 2 });
            //Assert
            actual.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TestGetSurchargeRateByIdAsync()
        {
            //Arrange
            var expected = new SurchargeRate { ProductTypeId = 3, SurchargeAmount = 200 };
            var request = new SurchargeRateRequestQuery
            {
                ProductTypeId = 3
            };
            _context.SurchargeRates.Add(new SurchargeRate
            {
                ProductTypeId = 3,
                SurchargeAmount = 200
            });

            // Act
            var actual = await _surchargeService.GetByIdAsync(request);
            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TestGetSurchargeRateByInvalidIdAsync()
        {
            //Arrange
            var request = new SurchargeRateRequestQuery
            {
                ProductTypeId = 4
            };
            // Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _surchargeService.GetByIdAsync(request));
        }
    }
}
