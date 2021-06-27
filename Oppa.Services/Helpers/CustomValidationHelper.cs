using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using System.Text.RegularExpressions;

namespace Oppa.Services.Helpers
{
    public static class CustomValidationHelper
    {
        private static readonly Regex phonePattern = new Regex(@"^5\d{8}$");
        private static readonly Regex privateIdPattern = new Regex(@"^\d{11}$");
        private static readonly Regex ibanPattern = new Regex(@"^GE\d{2}[A-Z]{2}\d{16}$");

        public static void ValidatePhone(this string phone, ref ServiceResponse response)
        {
            if (!phonePattern.IsMatch(phone))
                response.Errors.Add("Invalid Phone Number Format");
        }

        public static void ValidateTransactionAmount(this decimal amount, ref Product product, ref ServiceResponse response)
        {
            if (amount < product.TransactionMinAmount || amount > product.TransactionMaxAmount)
                response.Errors.Add($"Transaction Amount must be between {product.TransactionMinAmount} and {product.TransactionMaxAmount}");
        }

        public static void ValidatePrivateId(this string privateId, ref ServiceResponse response)
        {
            if (!privateIdPattern.IsMatch(privateId))
                response.Errors.Add("Private ID in incorrect format");
        }

        public static void ValidateIban(this string iban, ref ServiceResponse response)
        {
            if (!ibanPattern.IsMatch(iban))
                response.Errors.Add("Invalid Iban Format");
        }
    }
}
