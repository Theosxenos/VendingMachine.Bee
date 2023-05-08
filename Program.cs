Dictionary<string, float> products = new Dictionary<string, float>()
{
    {"Boot", 2 },
    {"Citroen", 5 },
    {"Deur", 6.6f },
    {"Egel", 5.33f },
    {"Hooi", 10.03f },

};

Console.WriteLine("BEE Vending\n===========");
Console.WriteLine("Het Menu:");

foreach (var product in products)
{
    // TODO format and align
    Console.WriteLine($"{product.Key}\t\t{product.Value}");
}

// Empty line for readability
Console.WriteLine();

string? selectedproduct = string.Empty;
do
{
    Console.WriteLine("Maak uw keuze:");
    
    selectedproduct = Console.ReadLine();
    var productvalue = products[selectedproduct];
    Console.WriteLine($"{selectedproduct}\t\t{productvalue}");
    
    Console.WriteLine("");

} while (!string.IsNullOrEmpty(selectedproduct));

Console.WriteLine("Bedankt voor uw bezoek.");
