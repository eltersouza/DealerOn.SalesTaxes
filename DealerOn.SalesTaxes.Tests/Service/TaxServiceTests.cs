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
        public void Test_Scenario_ExemptTax_NotImported_ShouldPass()
        {
            //Set the data
            var item = new Item(1, "Book", 12.49M, false, Domain.Enum.ItemCategoryEnum.Book);

            var tax = TaxService.CalculateTaxesForItem(item);
            
            Assert.Equal(0M,tax);
        }

        [Fact]
        public void Test_Scenario_HasTax_IsImported_ShouldBeEqual()
        {
            //Set the data
            var item = new Item(1, "Imported Chocolate", 0.85M, true, Domain.Enum.ItemCategoryEnum.Food);

            var tax = TaxService.CalculateTaxesForItem(item);

            Assert.Equal(0.05M, tax);
        }

        [Fact]
        public void Test_Scenario_HasTax_NotImported_ShouldBeEqual()
        {
            //Set the data
            var item = new Item(1, "Chocolate", 0.85M, false, Domain.Enum.ItemCategoryEnum.Food);

            var tax = TaxService.CalculateTaxesForItem(item);

            Assert.Equal(0.00M, tax);
        }

        [Fact]
        public void Test_Scenario_HasTax_Imported_ShouldNotBeEqual()
        {
            //Set the data
            var item = new Item(1, "Imported bottle of perfume", 47.50M, true, Domain.Enum.ItemCategoryEnum.Other);

            var tax = TaxService.CalculateTaxesForItem(item);

            Assert.NotEqual(7.12M, tax);
        }

        [Fact]
        public void Test_Scenario_HasTax_ImportedImported_ShouldBeEqual()
        {
            //Set the data
            var item = new Item(1, "Imported bottle of perfume", 47.50M, true, Domain.Enum.ItemCategoryEnum.Other);

            var tax = TaxService.CalculateTaxesForItem(item);

            Assert.Equal(7.15M, tax);
        }

        [Fact]
        public void Test_Scenario_ExemptTax_Imported_ShouldBeEqual()
        {
            //Set the data
            var item = new Item(1, "Imported Book", 12.49M, true, Domain.Enum.ItemCategoryEnum.Book);

            var tax = TaxService.CalculateTaxesForItem(item);

            Assert.Equal(0.65M, tax);
        }
    }
}
