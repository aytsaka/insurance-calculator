using Insurance.Domain.Interfaces;
using Insurance.Domain.Requests;
using System.Threading.Tasks;

namespace Insurance.Domain.Tests.Services
{
    public class TestInsuranceService : IInsuranceService
    {
        public void Dispose()
        {
        }

        public Task<double> GetInsuranceValueByOrderAsync(OrderInsuranceRequestQuery request)
        {
            return Task.FromResult(1000d);
        }

        public Task<double> GetInsuranceValueByProductIdAsync(int productId)
        {
            return Task.FromResult(1000d);
        }
    }
}
