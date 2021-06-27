using Oppa.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Data.ViewModels
{
    public class CreateTransactionViewModel
    {
        public decimal TransactionAmount { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public int? ServiceId { get; set; }
        public string PrivateId { get; set; }
        public string PhoneNumber { get; set; }
        public string Iban { get; set; }
    }
}
