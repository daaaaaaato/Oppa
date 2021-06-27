using Oppa.Data.Models;

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
