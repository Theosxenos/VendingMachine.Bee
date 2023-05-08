using VendingMachine.Bee.Models;

List<ProductModel> products = new List<ProductModel>()
{
    new ProductModel { Name = "Boot", Price = 2 },
    new ProductModel { Name = "Citroen", Price = 5 },
    new ProductModel { Name = "Deur", Price = 6.6f },
    new ProductModel { Name = "Egel", Price = 5.33f },
    new ProductModel { Name = "Hooi", Price = 10.03f },
};

Console.WriteLine("\t\tBEE Vending\t\t");
Console.WriteLine("\t\t===========\t\t");

Console.WriteLine("Het Menu:\n");

Console.WriteLine("Code\t\tNaam\t\tPrijs");
Console.WriteLine("----------------------------------------------");
for (int i = 0; i < products.Count; i++)
{
    ProductModel? product = products[i];
    // TODO format and align
    Console.WriteLine($"{i}\t\t{product.Name}\t\t{product.Price}");
}

// Empty line for readability
Console.WriteLine();

string? selectedproduct = string.Empty;
do
{
    Console.WriteLine("Maak uw keuze:");
    
    selectedproduct = Console.ReadLine();
    //var productvalue = products[selectedproduct];
    //Console.WriteLine($"{selectedproduct}\t\t{productvalue}");
    
    Console.WriteLine("");

} while (!string.IsNullOrEmpty(selectedproduct));

Console.WriteLine("Bedankt voor uw bezoek.");
