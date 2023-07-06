using DealerOn.SalesTaxes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Core.Services
{
    /// <summary>
    /// This service has the responsability to get code cleaner at the console application.
    /// </summary>
    public class ConsoleService
    {
        /// <summary>
        /// Checks if the input is Quit and exit application.
        /// </summary>
        /// <param name="line"></param>
        public static void CheckQuit(string? line)
        {
            if (line?.ToLower() == "quit")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Closing the application... Thank you for using DealerOn Sales Tax Application.");
                Console.ResetColor();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Checks if the input it receipt to inform the console application that the main loop should end and print the receipt.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool CheckReceipt(string? line)
        {
            return line?.ToLower() == "receipt";
        }

        /// <summary>
        /// Show Informations at the beginning of the console application.
        /// </summary>
        public static void ShowHeaderInformationText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to DealerOn Sales Tax Application");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
            Console.ResetColor();

            Console.WriteLine("Please provide the items for the Sale, 1 item per line.");
            Console.WriteLine();

            Console.WriteLine("The sale item should use the following format: {Quantity} {Imported?} {NameOfTheProduct} at {Price}, {Category}");
            Console.WriteLine("For example: 1 Book at 18.23, 1");
            Console.WriteLine("For example: 1 Imported bottle of perfume at 49.50, 0");
            Console.WriteLine();

            Console.WriteLine("The accepted values are:");
            Console.WriteLine("Price: Integer (10) | Decimal (10.99)");
            Console.WriteLine("Category: 1 - Book | 2 - Food | 3: Medical | 0: Other");
            Console.WriteLine();

            Console.WriteLine($"Type \"receipt\" to close the sale and print receipt.");
            Console.WriteLine($"Type \"quit\" to finish the application");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the header for the receipt part.
        /// </summary>
        public static void PrintReceiptHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("==== RECEIPT ====");
            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// Gets the list of items for the sale and calls a methods to show the receipt.
        /// </summary>
        /// <param name="listOfItems"></param>
        public static void PrintReceipt(List<Item> listOfItems)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ReceiptService.PrintReceipt(listOfItems);
            Console.ResetColor();
        }
    }
}
