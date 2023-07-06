using DealerOn.SalesTaxes.Core.Services;
using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Tests.Service
{
    public class TaxServiceTests
    {
        [Fact]
        public void Test_Scenario_Notax_ShouldPass()
        {
            //Set the data
            var item = new Item(1, "Book", 12.49M, false, Domain.Enum.ItemCategoryEnum.Book);

            var tax = TaxService.CalculateTaxesForItem(item);
            
            Assert.Equal(0M,tax);
        }

        [Fact]
        public void Test_Scenario_HasTax_ShouldPass()
        {
            //Set the data
            var item = new Item(1, "Imported Chocolate", 0.85M, true, Domain.Enum.ItemCategoryEnum.Food);

            var tax = TaxService.CalculateTaxesForItem(item);

            Assert.Equal(0.04M, tax);
        }

        [Fact]
        public void Test_Scenario_HasTax_ShouldNotBeEqual()
        {
            //Set the data
            var item = new Item(1, "Imported Chocolate", 0.85M, true, Domain.Enum.ItemCategoryEnum.Food);

            var tax = TaxService.CalculateTaxesForItem(item);

            Assert.NotEqual(2.50M, tax);
        }
    }
}
