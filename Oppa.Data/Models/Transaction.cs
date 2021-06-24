using Oppa.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oppa.Data.Models
{
    public class Transaction : BaseEntity<long>
    {
        public decimal CommisionAmount { get; set; }
        public decimal TransactionAmount { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public int? ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }
        public string PrivateId { get; set; }
        public string PhoneNumber { get; set; }
        public string Iban { get; set; }

    }
}
