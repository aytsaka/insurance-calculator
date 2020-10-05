using Insurance.Data.Context;
using Insurance.Data.Models;
using Insurance.Domain.Exceptions;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Requests;
using System.Threading.Tasks;

namespace Insurance.Domain.Services
{
    public class SurchargeService : BaseService, ISurchargeService
    {
        private readonly InsuranceDbContext _context;

        public SurchargeService(InsuranceDbContext context)
        {
            _context = context;
        }

        protected override void OnDispose()
        {
            _context.Dispose();
        }

        public async Task<SurchargeRate> GetByIdAsync(SurchargeRateRequestQuery request)
        {
            return await _context.SurchargeRates.FindAsync(request.ProductTypeId).ConfigureAwait(false) ?? throw new NotFoundException(string.Format("Product type is not found. Id: {0}", request.ProductTypeId)); ;
        }

        public async Task<bool> AddSurchargeRateAsync(SurchargeRateRequestPut request)
        {
            var surchargeRate = await _context.SurchargeRates.FindAsync(request.SurchargeRate.ProductTypeId).ConfigureAwait(false);
            if (surchargeRate == null)
            {
                await _context.AddAsync(request.SurchargeRate);
            }
            else
            {
                surchargeRate.SurchargeAmount = request.SurchargeRate.SurchargeAmount;
            }
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
