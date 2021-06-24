using Oppa.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oppa.Data.Models
{
    public class Product : BaseEntity<int>
    {
        public Product()
        {
            Services = new List<Service>();
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public decimal CommissionMinAmount { get; set; }
        public decimal CommisionPercentage { get; set; }
        public decimal TransactionMinAmount { get; set; }
        public decimal TransactionMaxAmount { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public virtual ICollection<Service> Services { get; set; }

    }
}
