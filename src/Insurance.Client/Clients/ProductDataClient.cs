using Insurance.Client.Exceptions;
using Insurance.Client.Interfaces;
using Insurance.Client.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insurance.Client.Clients
{
    public class ProductDataClient : BaseClient, IProductDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfigurationRoot _appConfig;
        public ProductDataClient(HttpClient httpClient, IConfigurationRoot appConfig)
        {
            _httpClient = httpClient;
            _appConfig = appConfig;
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int productTypeId)
        {
            var url = string.Format("{0}{1}", _appConfig.GetSection("ProductApi").Value, string.Format("/product_types/{0:G}", productTypeId));
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                // Success, so parse the JSON data into objects.
                var jsonData = response.Content.ReadAsStringAsync().Result;

                var data = JObject.Parse(jsonData);
                return data.ToObject<ProductType>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException(string.Format("Product type is not found. Id: {0}", productTypeId));
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var url = string.Format("{0}{1}", _appConfig.GetSection("ProductApi").Value, string.Format("/products/{0:G}", productId));
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                // Success, so parse the JSON data into objects.
                var jsonData = response.Content.ReadAsStringAsync().Result;

                var data = JObject.Parse(jsonData);
                return data.ToObject<Product>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException(string.Format("Product is not found. Id: {0} ", productId));
            }
            else
            {
                throw new Exception();
            }
        }

        protected override void OnDispose()
        {
            _httpClient.Dispose();
        }
    }
}
