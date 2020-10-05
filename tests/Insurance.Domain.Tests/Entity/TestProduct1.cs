using Insurance.Client.Models;

namespace Insurance.Domain.Tests.Entity
{
    public class TestProduct1 : Product
    {
        public TestProduct1()
        {
            Id = 1;
            Name = "Product1";
            ProductTypeId = 1;
            SalesPrice = 1000;
        }
    }
}
