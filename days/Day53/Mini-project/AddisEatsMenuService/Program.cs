using System.ComponentModel.Design;
using AddisEatsMenuService.Models;

var menuService = new MenuService();
try
{
    menuService.Add(new MenuItem(4, "Kitfo", "Main dish",600m));
    menuService.Add(new MenuItem(4, "Ingera", "Extra", 30m));
    menuService.Add(new MenuItem(4, "Brade", "Extra", 20m));
    menuService.Add(new MenuItem(4, "Sufe", "Side dish", 150m));
    menuService.Add(new MenuItem(4, "Telba", "Side dish", 100m));
}
catch(ArgumentException ex)
{
    Console.WriteLine($"validation vaild: {ex.Message}");
}
IReadOnlyList<MenuItem> allItems = menuService.GetAll();

Console.WriteLine("Addis Eats Menu Service");
Console.WriteLine("***********************************************************************");
Console.WriteLine("Every dish");
foreach (var item in allItems)
{
    Console.WriteLine($"Name: {item.Name}");
}

IReadOnlyList<MenuItem> allMainDish = menuService.GetByCategory("Main dish");

Console.WriteLine("");
Console.WriteLine("***********************************************************************");
Console.WriteLine("Every dish in main dish");

foreach (var item in allMainDish)
{
    Console.WriteLine($"Name: {item.Name}, Price: {item.Price}");
}

Console.WriteLine("");
Console.WriteLine("***********************************************************************");
Console.WriteLine("The Sum and Average of Main dish is");
Console.WriteLine(menuService.GetTotalAverageOf("Main dish"));

IDiscountPolicy tenPercentDiscount = new TenPercentDiscount();
IDiscountPolicy fiftyPercentDiscount = new FiftyPercentDiscount();

Console.WriteLine("");
Console.WriteLine("***********************************************************************");
Console.WriteLine($"Our discount");
foreach (var item in allItems)
{
    decimal newPrice = item.Price switch
    {
        >= 500 => fiftyPercentDiscount.ApplyDiscount(item.Price),
        >= 100 => tenPercentDiscount.ApplyDiscount(item.Price),
        _ => 0m
    };
    Console.WriteLine($"Name: {item.Name}, Price: {item.Price} After Discount: {newPrice}");
}