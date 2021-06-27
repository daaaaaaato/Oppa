﻿using Oppa.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Data.ViewModels
{
    public class UpdateProductViewModel
    {
        public string Name { get; set; }
        public decimal CommissionMinAmount { get; set; }
        public decimal CommisionPercentage { get; set; }
        public decimal TransactionMinAmount { get; set; }
        public decimal TransactionMaxAmount { get; set; }
        public ProductTypeEnum ProductType { get; set; }
    }
}
