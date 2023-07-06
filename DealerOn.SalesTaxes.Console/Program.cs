//This console application is using .net 6 and top level statement
using DealerOn.SalesTaxes.Core.Services;
using DealerOn.SalesTaxes.Domain.Models;

//Shows information to guide the user
ConsoleService.ShowHeaderInformationText();

var listOfItems = new List<Item>();

while (true)
{
    Console.Write($"Entry: ");
    var line = Console.ReadLine();

    ConsoleService.CheckQuit(line);
    if (ConsoleService.CheckReceipt(line)) break;

    if (ValidationService.ValidateSaleItem(line))
    {
        var item = ItemService.ConvertToItem(line!);
        Console.WriteLine($"Item added: {item.Quantity} - {item.Name}");
        listOfItems.Add(item);
    }
    else
    {
        Console.WriteLine($"Invalid entry, please enter a valid sale item or type 'receipt' or 'quit'.");
    }
}

ConsoleService.PrintReceiptHeader();
ConsoleService.PrintReceipt(listOfItems);