using Insurance.Data.Models;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Requests;
using Insurance.Domain.Tests.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Domain.Tests.Services
{
    public class TestSurchargeService : ISurchargeService
    {
        public void Dispose()
        {
        }

        public Task<bool> AddSurchargeRateAsync(SurchargeRateRequestPut request)
        {
            return Task.FromResult(true);
        }

        public Task<SurchargeRate> GetByIdAsync(SurchargeRateRequestQuery request)
        {
            return Task.FromResult(GetProductTypeDataSet().FirstOrDefault(x => x.ProductTypeId == request.ProductTypeId));
        }

        private IEnumerable<SurchargeRate> GetProductTypeDataSet()
        {
            return new SurchargeRate[] {
                new TestSurchargeRate1(),
                new TestSurchargeRate2()
            };
        }
    }
}
