Console.WriteLine("Wellcome to Addis Eats Top Up Application!");
Console.WriteLine("                                           ");

Console.WriteLine("*******************************************");
Console.WriteLine("Get bounce up to five percent");
Console.WriteLine("get 5% bounce for Ethio Telecom, 3% bounce for Safaricom");
Console.WriteLine("  ");

Console.WriteLine("*******************************************");
Console.WriteLine("Enter Your name");
string nameEntry = Console.ReadLine();
Console.WriteLine(" ");

bool nameFlag = true;
while (nameFlag)
{
    if (int.TryParse(nameEntry, out int nameCheker))
    {
        Console.WriteLine("Please Enter Valid Name");
        nameEntry = Console.ReadLine();
    }
    else
    {
        nameFlag = false;
    }
}
string name = nameEntry;

Console.WriteLine(" ");
Console.WriteLine("Enter 1 For Ethio Telecom 2 for Safaricom");
string networkEntry = Console.ReadLine();
Console.WriteLine(" ");

bool networlFlag = true;
while (networlFlag)
{
    if (!int.TryParse(networkEntry, out int networkCheker))
    {
        Console.WriteLine(" ");
        Console.WriteLine("Please Enter 1 For Ethio Telecom or 2 for Safaricom Only number");
        networkEntry = Console.ReadLine();
    }
    else if(networkCheker != 1 && networkCheker != 2)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Please Enter 1 For Ethio Telecom or 2 for Safaricom Only number");
        networkEntry = Console.ReadLine();
    }
    else
    {
        networlFlag = false;
    }
}
int network = int.Parse(networkEntry);

Console.WriteLine(" ");
Console.WriteLine("Enter Top Up Amount");
string AmountEntry = Console.ReadLine();

bool amountFlag = true;
while (amountFlag)
{
    if (!decimal.TryParse(AmountEntry, out decimal amountCheker))
    {
        Console.WriteLine("Please Enter Only number");
        AmountEntry = Console.ReadLine();
    }
    else if (amountCheker < 5)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Minimum Amount Alowed 5 Enter Amount Again");
        AmountEntry = Console.ReadLine();
    }
    else if (amountCheker > 5000)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Maximum Amount Alowed 5000 Enter Amount Again");
        AmountEntry = Console.ReadLine();
    }
    else
    {
        amountFlag = false;
    }
}


decimal amount = decimal.Parse(AmountEntry);
decimal bonus = network switch
{
    1 => 0.05m * amount,
    2 => 0.03m * amount,
    _   => 0m
};
decimal extraBonus = amount >= 1000 ? 20m : 0m;

string carier = network switch
{
    1 => "Ethio Telecom",
    2 => "Safaricom",
    _   => "Other"
};
decimal finalAmount = amount + bonus + extraBonus;

Console.WriteLine(" ");
Console.WriteLine("*******************************************");
Console.WriteLine(" ");

Console.WriteLine($"Helo: {name:N2}");
Console.WriteLine($"Carrier: {carier:N2}");
Console.WriteLine($"Amount {amount:N2}");
Console.WriteLine($"Bonus: {bonus:N2}");
Console.WriteLine($" extra Bonus: {extraBonus:N2}");
Console.WriteLine($"Final Amount Toped up: {finalAmount:N2}");
