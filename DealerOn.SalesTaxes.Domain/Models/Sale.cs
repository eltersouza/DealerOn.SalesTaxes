using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Domain.Models
{
    /// <summary>
    /// Sale Model
    /// </summary>
    public class Sale
    {
        public List<Item> Items { get; set; }
        public decimal TotalGross { get; set; }
        public decimal TotalNet { get; set; }
        public decimal Taxes { get; set; }

        public Sale()
        {
            Items = new List<Item>();
        }
    }
}
