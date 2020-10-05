using Insurance.Data.Models;

namespace Insurance.Domain.Tests.Entity
{
    public class TestSurchargeRate2 : SurchargeRate
    {
        public TestSurchargeRate2()
        {
            ProductTypeId = 2;
            SurchargeAmount = 200;
        }
    }
}
