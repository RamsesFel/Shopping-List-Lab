Dictionary<string, decimal> storeItems = new Dictionary<string, decimal>();
List<string> reciptname = new List<string>();
List<decimal> reciptprice = new List<decimal>();
List<string> orderedreciptname = new List<string>();
List<decimal> orderedreciptprice = new List<decimal>();
storeItems.Add("1. Soda", 1.00m);
storeItems.Add("2. Coffee", 1.50m);
storeItems.Add("3. Candy", 1.00m);
storeItems.Add("4. Chips", 1.50m);
storeItems.Add("5. Dougnut", 0.89m);
storeItems.Add("6. Muffin", 1.25m);
storeItems.Add("7. Gum", 1.00m);
storeItems.Add("8. Slushie", 1.50m);
bool shopping = true;
decimal ordercost = 0;
bool validanswer = false;
Console.WriteLine("Welcome! What would you like?\n");

while (shopping)
{
    foreach (KeyValuePair<string, decimal> item in storeItems)
    {
        Console.WriteLine($"{item.Key,-20}${item.Value}");
    }

    string order = Console.ReadLine().ToLower();
    validanswer = false;
    foreach (KeyValuePair<string, decimal> item in storeItems)
    {
        if (item.Key.ToLower().Contains(order))
        {
            Console.WriteLine($"Added to your cart: {item.Key,-10}${item.Value}");
            reciptname.Add(item.Key);
            reciptprice.Add(item.Value);
            ordercost += item.Value;
            validanswer = true;
        }
    }
    if (!validanswer)
    {
        Console.WriteLine("We don't have that item please pick something from the list.");
        continue;
    }
    while (true)
    {
        Console.WriteLine("Would you like anything else? y/n");
        string answer = Console.ReadLine();
        if (answer == "y")
        {
            break;
        }
        else if (answer == "n")
        {
            shopping = false;
            break;
        }
        else
        {
            Console.WriteLine("I'm sorry I don't understand.");
        }
    }
}
int reciptlength = reciptname.Count();
for (int i = 0; i < reciptlength; i++)
{
    decimal mostExpensivePrice = 0;
    string mostExpensiveName = "";
    for (int x = 0; x < reciptname.Count; x++)
    {
        if (reciptprice[x] > mostExpensivePrice)
        {
            mostExpensivePrice = reciptprice[x];
            mostExpensiveName = reciptname[x];
        }
    }
    orderedreciptname.Add(mostExpensiveName);
    orderedreciptprice.Add(mostExpensivePrice);
    reciptprice.Remove(mostExpensivePrice);
    reciptname.Remove(mostExpensiveName);
}
for (int i = 0; i < orderedreciptname.Count; i++)
{
    Console.WriteLine($"{orderedreciptname[i],-20}${orderedreciptprice[i]}");
}
Console.WriteLine($"That will be ${ordercost}");