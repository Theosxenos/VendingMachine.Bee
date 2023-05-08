namespace VendingMachine.Bee;

public class MainView
{
    VendingMachineViewModel vm;

    public MainView(VendingMachineViewModel viewModel)
    {
        vm = viewModel;
    }

    public void Run()
    {
        ShowMenu();
    }

    private void ShowMenu()
    {
        Console.WriteLine("\t\tBEE Vending\t\t");
        Console.WriteLine("\t\t===========\t\t");

        Console.WriteLine("Het Menu:\n");

        Console.WriteLine("Code\t\tNaam\t\tPrijs");
        Console.WriteLine("----------------------------------------------");

        var products = vm.GetProducts();

        for (int i = 0; i < products.Count; i++)
        {
            ProductModel? product = products[i];
            // TODO format and align
            Console.WriteLine($"{i + 1}\t\t{product.Name}\t\t{product.Price}");
        }

        // Empty line for readability
        //Console.WriteLine();

        HandleUserInput();
    }

    private void HandleUserInput()
    {
        int productcode = 0;
        do
        {
            // Evt. ook naam?
            Console.WriteLine("\nMaak uw keuze ahv productcode of gebruik 'q' om te stoppen:");

            // TODO Error Handling
            var userinput = Console.ReadLine();
            
            if(userinput == "q")
            {
                productcode = -1;
                continue;
            }

            int.TryParse(userinput, out productcode);
            ShowProduct(productcode - 1);

            Console.WriteLine("");

        } while (productcode >= 1);

        Console.WriteLine("\nBedankt voor uw bezoek.");
    }

    private void ShowProduct(int productcode)
    {
        var product = vm.GetProduct(productcode);
        Console.WriteLine($"\nProductnaam: {product.Name}\tProductprijs: {product.Price}");
    }
}
