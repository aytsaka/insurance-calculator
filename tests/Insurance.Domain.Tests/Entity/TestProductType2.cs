using Insurance.Client.Models;

namespace Insurance.Domain.Tests.Entity
{
    public class TestProductType2 : ProductType
    {
        public TestProductType2()
        {
            Id = 2;
            Name = "Smartphones";
            CanBeInsured = true;
        }
    }
}
