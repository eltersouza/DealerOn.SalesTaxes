using DealerOn.SalesTaxes.Domain.Enum;
using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Core.Services
{
    /// <summary>
    /// Service responsible for all taxes calculations.
    /// </summary>
    public class TaxService
    {
        /// <summary>
        /// Checks if the item is exempt from taxation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true or false depending if the Item is exempted</returns>
        private static bool CheckIfIsExemptFromTaxes(Item item)
        {
            return item.Category != ItemCategoryEnum.Other;
        }

        /// <summary>
        /// Do the calculations of taxes for the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The value (in decimal) for the taxation for a particular item.</returns>
        public static decimal CalculateTaxesForItem(Item item)
        {
            decimal taxes = 0.0M;

            if (!CheckIfIsExemptFromTaxes(item))
                taxes += item.Price * 0.1M;

            if (item.IsImported)
                taxes += item.Price * 0.05M;

            return taxes;
        }
    }
}
