using Insurance.Data.Models;

namespace Insurance.Domain.Tests.Entity
{
    public class TestSurchargeRate1 : SurchargeRate
    {
        public TestSurchargeRate1()
        {
            ProductTypeId = 1;
            SurchargeAmount = 100;
        }
    }
}
