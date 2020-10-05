using Insurance.Client.Models;

namespace Insurance.Domain.Tests.Entity
{
    public class TestProductType3 : ProductType
    {
        public TestProductType3()
        {
            Id = 3;
            Name = "ProductType";
            CanBeInsured = false;
        }
    }
}
