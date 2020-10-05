using Insurance.Client.Models;

namespace Insurance.Domain.Tests.Entity
{
    public class TestProduct3 : Product
    {
        public TestProduct3()
        {
            Id = 3;
            Name = "Product3";
            ProductTypeId = 3;
            SalesPrice = 1000;
        }
    }
}
