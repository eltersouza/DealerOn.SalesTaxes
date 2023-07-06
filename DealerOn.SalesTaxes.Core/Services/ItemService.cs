using DealerOn.SalesTaxes.Domain.Enum;
using DealerOn.SalesTaxes.Domain.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DealerOn.SalesTaxes.Core.Services
{
    /// <summary>
    /// This class has the responsability to deal with all information about Item class
    /// </summary>
    public class ItemService
    {
        /// <summary>
        /// Gets an input and converts it to an Item in the sale.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Item ConvertToItem(string inputString)
        {
            try
            {
                _ = int.TryParse(inputString.Split(" ")[0].Trim(), out int quantity);

                var value = inputString.Split(" at ")[1];
                value = value.Split(",")[0].Trim();

                _ = decimal.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out decimal price);

                var itemName = Regex.Replace(inputString.Substring(0, inputString.IndexOf(" at ")), @"\d+", "").Trim();
                bool isImported = inputString.ToLower().IndexOf("imported") > -1;
                ItemCategoryEnum categoryEnum = (ItemCategoryEnum) Enum.Parse(typeof(ItemCategoryEnum), inputString.Split(",")[1].Trim(), true);

                var item = new Item(quantity, itemName, price, isImported, categoryEnum);

                return item;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
