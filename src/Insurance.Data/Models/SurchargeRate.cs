using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance.Data.Models
{
    [Table("surchargerates")]
    public class SurchargeRate
    {
        [Key]
        public int ProductTypeId { get; set; }

        public double SurchargeAmount { get; set; }
    }
}
