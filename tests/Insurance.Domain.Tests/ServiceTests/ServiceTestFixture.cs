using Insurance.Client.Interfaces;
using Insurance.Data.Context;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Services;
using Insurance.Domain.Tests.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Insurance.Domain.Tests.ServiceTests
{
    public class ServiceTestFixture : IDisposable
    {
        public ServiceProvider ServiceProvider { get; }

        public ServiceTestFixture()
        {
            var services = new ServiceCollection();
            services.AddTransient<IProductDataClient, TestProductDataClient>();
            services.AddDbContext<InsuranceDbContext>(options => options.UseInMemoryDatabase(databaseName: "InsuranceDb"));
            services.AddTransient<IInsuranceService, InsuranceService>();
            services.AddTransient<ISurchargeService, SurchargeService>();
            ServiceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
