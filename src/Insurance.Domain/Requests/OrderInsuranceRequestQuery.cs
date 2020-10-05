using System.Collections.Generic;

namespace Insurance.Domain.Requests
{
    public class OrderInsuranceRequestQuery
    {
        public IEnumerable<int> Products { get; set; }
    }
}