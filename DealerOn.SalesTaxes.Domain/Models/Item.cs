using DealerOn.SalesTaxes.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Domain.Models
{
    /// <summary>
    /// Item Model
    /// </summary>
    public class Item
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsImported { get; set; }
        public ItemCategoryEnum Category { get; set; }

        public decimal? Total { get; set; }
        public decimal? Taxes { get; set; }

        public Item(int quantity, string name, decimal price, bool isImported, ItemCategoryEnum category)
        {
            Quantity = quantity;
            Name = name;
            Price = price;
            IsImported = isImported;
            Category = category;
        }
    }
}
