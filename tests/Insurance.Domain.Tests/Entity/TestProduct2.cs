using Insurance.Client.Models;

namespace Insurance.Domain.Tests.Entity
{
    public class TestProduct2 : Product
    {
        public TestProduct2()
        {
            Id = 2;
            Name = "Product2";
            ProductTypeId = 2;
            SalesPrice = 3000;
        }
    }
}
