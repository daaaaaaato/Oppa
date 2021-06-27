using Oppa.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Services.Helpers
{
    public static class CommisionHelper
    {
        public static decimal CalculateCommision(this decimal amount, ref Product product)
        {
            var comAmmount = amount * product.CommisionPercentage / 100;

            return comAmmount >= product.CommissionMinAmount ? comAmmount : product.CommissionMinAmount;
        }
    }
}
