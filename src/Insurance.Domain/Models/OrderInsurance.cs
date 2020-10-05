using Insurance.Client.Models;
using System.Collections.Generic;

namespace Insurance.Domain.Models
{
    public class OrderInsurance
    {
        public double InsuranceValue { get; set; }

        public virtual IEnumerable<ProductType> ProductTypes { get; set; }
    }
}