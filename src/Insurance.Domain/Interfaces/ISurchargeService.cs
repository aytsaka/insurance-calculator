using Insurance.Data.Models;
using Insurance.Domain.Requests;
using System.Threading.Tasks;

namespace Insurance.Domain.Interfaces
{
    public interface ISurchargeService : IBaseService
    {
        Task<SurchargeRate> GetByIdAsync(SurchargeRateRequestQuery request);

        Task<bool> AddSurchargeRateAsync(SurchargeRateRequestPut request);
    }
}