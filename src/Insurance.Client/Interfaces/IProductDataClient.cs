using Insurance.Client.Models;
using System.Threading.Tasks;

namespace Insurance.Client.Interfaces
{
    public interface IProductDataClient : IBaseClient
    {
        Task<ProductType> GetProductTypeByIdAsync(int productTypeId);

        Task<Product> GetProductByIdAsync(int productId);
    }
}
