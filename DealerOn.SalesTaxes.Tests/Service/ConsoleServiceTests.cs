using DealerOn.SalesTaxes.Core.Services;
using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Tests.Service
{
    public class ConsoleServiceTests
    {
        private readonly StringWriter _consoleOutput;

        public ConsoleServiceTests()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        [Fact]
        public void Test_Scenario1()
        {

            var inputArr = new string[] {
                                        "1 Book at 12.49,1",
                                        "1 Book at 12.49,1",
                                        "1 Music CD at 14.99,0",
                                        "1 Chocolate bar at 0.85,2"
                                    };

            var listOfItems = new List<Item>();
            foreach(var input in inputArr)
            {
                listOfItems.Add(ItemService.ConvertToItem(input));
            }

            ConsoleService.PrintReceipt(listOfItems);

            var output = _consoleOutput.ToString().Split("\r\n");

            Assert.Equal("Book: 24.98 (2 @ 12.49)", output[0]);
            Assert.Equal("Music CD: 16.49", output[1]);
            Assert.Equal("Chocolate bar: 0.85", output[2]);
            Assert.Equal("Sales Taxes: 1.50", output[4]);
            Assert.Equal("Total: 42.32", output[5]);
        }

        [Fact]
        public void Test_Scenario2()
        {

            var inputArr = new string[] {
                                        "1 Imported box of chocolates at 10.00, 2",
                                        "1 Imported bottle of perfume at 47.50, 0"
                                    };

            var listOfItems = new List<Item>();
            foreach (var input in inputArr)
            {
                listOfItems.Add(ItemService.ConvertToItem(input));
            }

            ConsoleService.PrintReceipt(listOfItems);

            var output = _consoleOutput.ToString().Split("\r\n");

            Assert.Equal("Imported box of chocolates: 10.50", output[0]);
            Assert.Equal("Imported bottle of perfume: 54.62", output[1]);
            Assert.Equal("Sales Taxes: 7.62", output[3]);
            Assert.Equal("Total: 65.12", output[4]);
        }

        [Fact]
        public void Test_Scenario3()
        {

            var inputArr = new string[] {
                                        "1 Imported bottle of perfume at 27.99, 0",
                                        "1 Bottle of perfume at 18.99, 0",
                                        "1 Packet of headache pills at 9.75,3",
                                        "1 Imported box of chocolates at 11.25, 1",
                                        "1 Imported box of chocolates at 11.25, 1"
                                    };

            var listOfItems = new List<Item>();
            foreach (var input in inputArr)
            {
                listOfItems.Add(ItemService.ConvertToItem(input));
            }

            ConsoleService.PrintReceipt(listOfItems);

            var output = _consoleOutput.ToString().Split("\r\n");

            Assert.Equal("Imported bottle of perfume: 32.19", output[0]);
            Assert.Equal("Bottle of perfume: 20.89", output[1]);
            Assert.Equal("Packet of headache pills: 9.75", output[2]);
            Assert.Equal("Imported box of chocolates: 23.62 (2 @ 11.25)", output[3]);
            Assert.Equal("Sales Taxes: 7.22", output[5]);
            Assert.Equal("Total: 86.45", output[6]);
        }
    }
}
