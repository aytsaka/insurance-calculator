using Insurance.Client.Interfaces;
using Insurance.Client.Models;
using Insurance.Data.Context;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Models;
using Insurance.Domain.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Domain.Services
{
    public class InsuranceService : BaseService, IInsuranceService
    {
        private readonly IProductDataClient _productDataClient;
        private readonly InsuranceDbContext _context;

        public InsuranceService(IProductDataClient productDataClient,
                                InsuranceDbContext context)
        {
            _productDataClient = productDataClient;
            _context = context;
        }

        protected override void OnDispose()
        {
            _productDataClient.Dispose();
            _context.Dispose();
        }

        public async Task<double> GetInsuranceValueByProductIdAsync(int productId)
        {
            return (await CalculateInsuranceValueByProductId(productId).ConfigureAwait(false)).InsuranceValue;
        }

        public async Task<double> GetInsuranceValueByOrderAsync(OrderInsuranceRequestQuery request)
        {
            var insuranceValue = 0d;
            var productTypes = new List<ProductType>();
            foreach (var item in request.Products)
            {
                var result = await CalculateInsuranceValueByProductId(item).ConfigureAwait(false);
                insuranceValue += result.InsuranceValue;
                if (result.ProductTypes != null && !productTypes.Exists(x => x.Id == result.ProductTypes?.FirstOrDefault().Id))
                {
                    productTypes.Add(result.ProductTypes.FirstOrDefault());
                }
            }
            if (productTypes.Where(x => x.Name == "Digital cameras").Any())
            {
                insuranceValue += 500;
            }
            insuranceValue += await CalculateSurchargeValue(productTypes).ConfigureAwait(false);
            return insuranceValue;
        }

        private async Task<OrderInsurance> CalculateInsuranceValueByProductId(int productId)
        {
            var product = await _productDataClient.GetProductByIdAsync(productId).ConfigureAwait(false);
            var productType = await _productDataClient.GetProductTypeByIdAsync(product.ProductTypeId).ConfigureAwait(false);

            var insuranceValue = 0;
            if (!productType.CanBeInsured)
            {
                return new OrderInsurance();
            }

            if (product.SalesPrice >= 500 && product.SalesPrice < 2000)
            {
                insuranceValue = 1000;
            }
            else if (product.SalesPrice >= 2000)
            {
                insuranceValue = 2000;
            }

            if (productType.Name == "Laptops" || productType.Name == "Smartphones")
            {
                insuranceValue += 500;
            }
            return new OrderInsurance() { InsuranceValue = insuranceValue, ProductTypes = new List<ProductType> { new ProductType { Id = productType.Id, Name = productType.Name } } };
        }

        private async Task<double> CalculateSurchargeValue(IEnumerable<ProductType> productTypes)
        {
            var totalSurchargeRate = 0d;
            foreach (var item in productTypes)
            {
                var surchargeRate = await _context.SurchargeRates.FindAsync(item.Id).ConfigureAwait(false);
                if (surchargeRate != null)
                {
                    totalSurchargeRate += surchargeRate.SurchargeAmount;
                }
            }
            return totalSurchargeRate;
        }
    }
}
