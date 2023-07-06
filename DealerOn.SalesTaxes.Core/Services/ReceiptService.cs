using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Core.Services
{
    /// <summary>
    /// This class has the responsability to deal with the receipt.
    /// </summary>
    public class ReceiptService
    {
        /// <summary>
        /// Receives a list of Items and Prints each line accordingly
        /// </summary>
        /// <param name="items"></param>
        public static void PrintReceipt(IEnumerable<Item> items)
        {
            //Calculates the taxation for each Item in the Sale.
            var sale = SaleService.CalculateSale(items);

            foreach(var item in sale.Items)
            {
                var line = $"{item.Name}: {item.Total.GetValueOrDefault().ToString("F2", CultureInfo.GetCultureInfo("en-US"))}";

                if (item.Quantity > 1)
                    line += $" ({item.Quantity} @ {item.Price.ToString("F2", CultureInfo.GetCultureInfo("en-US"))})";

                Console.WriteLine(line);
            }
            
            Console.WriteLine();
            Console.WriteLine($"Sales Taxes: {sale.Taxes.ToString("F2", CultureInfo.GetCultureInfo("en-US"))}");
            Console.WriteLine($"Total: {sale.TotalGross.ToString("F2", CultureInfo.GetCultureInfo("en-US"))}");
            Console.ResetColor();
        }
    }
}
