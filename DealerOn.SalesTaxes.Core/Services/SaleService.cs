using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Core.Services
{
    /// <summary>
    /// This class has the responsability to deal with the actual Sale.
    /// </summary>
    public class SaleService
    {
        /// <summary>
        /// Gets a list of items and calculate all the totals.
        /// </summary>
        /// <param name="items"></param>
        /// <returns>A Sale object which has all items, totals and taxes calculated.</returns>
        public static Sale CalculateSale(IEnumerable<Item> items)
        {
            var sale = new Sale();

            var totalGross = 0M;
            var totalNet = 0M;
            var taxes = 0M;

            items.ToList().ForEach(item =>
            {
                var itemTax = TaxService.CalculateTaxesForItem(item);
                var itemPriceWithTax = (item.Price + itemTax) * item.Quantity;
                var itemPriceWithoutTax = item.Price * item.Quantity;

                item.Total = itemPriceWithTax;
                item.Taxes = itemTax * item.Quantity;
                item.Price = item.Price + itemTax;

                totalGross += itemPriceWithTax;
                totalNet += itemPriceWithoutTax;
                taxes += itemTax;

                if (sale.Items.Any(it => it.Name == item.Name))
                {
                    var itemToUpdate = sale.Items.Single(it => it.Name == item.Name);
                    itemToUpdate.Quantity += item.Quantity;
                    itemToUpdate.Total = itemToUpdate.Total * itemToUpdate.Quantity;
                    itemToUpdate.Taxes = itemToUpdate.Taxes * itemToUpdate.Quantity;
                }
                else
                {
                    sale.Items.Add(item);
                }
            });

            sale.TotalGross = totalGross;
            sale.TotalNet = totalNet;
            sale.Taxes = taxes;

            return sale;
        }
    }
}
