using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Core.Services
{
    /// <summary>
    /// This service has the responsability to deal to all validations
    /// </summary>
    public class ValidationService
    {
        /// <summary>
        /// Validates if the input can be interpreted to generate an actual object from it.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>true or false if the input passes the validation.</returns>
        public static bool ValidateSaleItem(string? inputString)
        {
            inputString = inputString?.Trim();
            if (string.IsNullOrWhiteSpace(inputString))
                return false;

            try
            {
                var value = inputString.Split(" at ")[1];
                value = value.Split(",")[0].Trim();

                var priceValid = decimal.TryParse(value, out decimal price);

                var quantityValid = int.TryParse(inputString.Split(" ")[0].Trim(), out int quantity);
                
                string[] categoryOptions = { "1", "2", "3", "0" };
                var categoryValid = categoryOptions.Contains(inputString.Split(",")[1].Trim());

                return quantityValid && priceValid && categoryValid;
            }
            catch
            {
                return false;
            }
        }
    }
}
