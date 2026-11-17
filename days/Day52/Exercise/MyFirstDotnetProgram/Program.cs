//Day 53 Exercise
//Console.WriteLine("Hello, Sq8!");

//int x =10;
//decimal y = 20.5m;
//double z = 10.5;
//bool isTrue = true;
//string name = "amanual";
//char letter = 'a';
//DateTime date = DateTime.Now;

//Console.WriteLine(date);

//var n = new List<string>();
//n.Add("berhanu");

//Console.Write(n[0]);
//Console.WriteLine($" is in list of size: {n.Count}");

//string? nullName = null;

//Console.WriteLine(nullName ?? "no Name");

//Console.WriteLine("please, enter your name: ");
//var userName = Console.ReadLine();
//Console.WriteLine($"Hello, {userName}");

//decimal price = 10.5m;
//Console.WriteLine($"The price is {price:N2} ETB");

//string a = "123";
//var b = int.Parse(a);
//Console.WriteLine(b + 100);

//if (int.TryParse(a, out int result))
//{
//    Console.WriteLine($"Success! The Nuber is: {result}");
//}
//else
//{
//    Console.WriteLine("Invalid format. Conversion faild");
//}

//int tot = 35;
//switch(tot)
//{
//    case 30:
//        Console.WriteLine("the total is equals to 35!");
//        break;
//    case 35:
//        Console.WriteLine("the total is equals to 35!");
//        break;
//    case 40:
//        Console.WriteLine("the total is equals to 35!");
//        break;
//    default:
//        Console.WriteLine("the total is grater than 40 or less than 30");
//            break;
//}

//string c = "Abeba";
//String[] peopleNames = { "Abeba", "Kebeda", "Almaz" };
//Console.WriteLine(peopleNames[2]);

//for (int i = 0; i < peopleNames.Length; i++)
//{
//    Console.WriteLine($"Hi {peopleNames[i]}");
//}

//foreach(string peopleName in peopleNames)
//{
//    Console.WriteLine($"Hello: {peopleName}");
//}

using MyFirstDotnetProgram.Models;

decimal Add(decimal a, decimal b)
{
    return a + b;
}
Console.WriteLine(Add(10.5m, 5.5m));

Console.WriteLine(CalculateBonus(500m));
//Console.WriteLine(CalculateBonus(500m, true));

decimal CalculateBonus(decimal price, decimal rate = 0.15m)
{
    return price * rate;
}

//decimal CalculateBonus(decimal price, bool isManager, decimal rate = 0.15m)
//{
//    if (isManager) 
//    {
//        return price * (rate + 0.05m);
//    }
//    return price * rate;
//}

MenuItem menuItem = new MenuItem(1, "Burger", "Food", 1.5m);

Console.WriteLine($"Menu Item: Name: {menuItem.Name} Price: {menuItem.Price}");

List<MenuItem> myMenuItems = new List<MenuItem>
{
    new MenuItem(1, "Burger", "Food", 10.5m),
    new MenuItem(2, "Pizza", "Food", 15.0m),
    new MenuItem(3, "Coke", "Drink", 2.5m),
    new MenuItem(4, "Water", "Drink", 1.0m),
    new MenuItem(5, "Salad", "Food", 8.0m),
    new MenuItem(6, "Fries", "Food", 3.5m),
    new MenuItem(7, "Ice Cream", "Dessert", 4.0m)
};

// LINQ Queries

var foodItems = myMenuItems.Where(i => i.Category == "Food");

foreach (var foodItem in foodItems)
{
    Console.WriteLine($"Fod Item Name: {foodItem.Name} Price with vat: {foodItem.PriceWithVAT}");
}

//SELECT Clause

var prices = myMenuItems.Select(i => i.Price).ToList();

foreach (var price in prices)
{
    Console.WriteLine($"PRice: {price}");
}

// Any Clause
bool hasExpensiveItem = myMenuItems.Any(i => i.Price > 10.0m);
Console.WriteLine($"Has expensive item: {hasExpensiveItem}");

// ALL Clause
bool allExpensiveItem = myMenuItems.All(i => i.Price > 10.0m);
Console.WriteLine($"Is All are expensive item: {allExpensiveItem}");

// Sum and Average
decimal sumOfItem = myMenuItems.Sum(i => i.Price);
decimal averageOfItem = myMenuItems.Average(i => i.Price);
Console.WriteLine($"The sum price of Items: {sumOfItem}");
Console.WriteLine($"The average price of Items: {averageOfItem}");