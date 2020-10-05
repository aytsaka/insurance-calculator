using Insurance.Domain.Interfaces;
using Insurance.Domain.Tests.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Insurance.Api.Tests.ControllerTests
{
    public class ControllerTestFixture : IDisposable
    {
        public ServiceProvider ServiceProvider { get; }

        public ControllerTestFixture()
        {
            var services = new ServiceCollection();
            services.AddTransient<IInsuranceService, TestInsuranceService>();
            services.AddTransient<ISurchargeService, TestSurchargeService>();
            services.AddControllers();
            ServiceProvider = services.BuildServiceProvider();
        }

        public void Dispose() => ServiceProvider.Dispose();
    }
}
