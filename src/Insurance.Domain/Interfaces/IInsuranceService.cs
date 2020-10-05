using Insurance.Domain.Requests;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces
{
    public interface IInsuranceService : IBaseService
    {
        Task<double> GetInsuranceValueByProductIdAsync(int productId);

        Task<double> GetInsuranceValueByOrderAsync(OrderInsuranceRequestQuery request);
        
    }
}
