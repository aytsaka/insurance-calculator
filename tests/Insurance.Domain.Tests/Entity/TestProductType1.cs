using Insurance.Client.Models;

namespace Insurance.Domain.Tests.Entity
{
    public class TestProductType1 : ProductType
    {
        public TestProductType1()
        {
            Id = 1;
            Name = "Digital cameras";
            CanBeInsured = true;
        }
    }
}
