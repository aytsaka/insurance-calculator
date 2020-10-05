using Insurance.Client.Interfaces;
using Insurance.Client.Models;
using Insurance.Domain.Tests.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Domain.Tests.Clients
{
    public class TestProductDataClient : IProductDataClient
    {
        public void Dispose()
        {
        }

        public Task<Product> GetProductByIdAsync(int productId)
        {
            return Task.FromResult(GetProductDataSet().FirstOrDefault(x => x.Id == productId));
        }

        public Task<ProductType> GetProductTypeByIdAsync(int productTypeId)
        {
            return Task.FromResult(GetProductTypeDataSet().FirstOrDefault(x => x.Id == productTypeId));
        }

        private IEnumerable<Product> GetProductDataSet()
        {
            return new Product[] {
                new TestProduct1(),
                new TestProduct2(),
                new TestProduct3()
            };
        }

        private IEnumerable<ProductType> GetProductTypeDataSet()
        {
            return new ProductType[] {
                new TestProductType1(),
                new TestProductType2(),
                new TestProductType3(),
                new TestProductType3()
            };
        }
    }
}
