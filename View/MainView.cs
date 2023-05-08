namespace VendingMachine.Bee;

public class MainView
{
    VendingMachineViewModel vm;
    UserModel user;

    public MainView(VendingMachineViewModel viewModel, UserModel userModel)
    {
        user = userModel;
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

        Console.WriteLine("Code\t\tNaam\t\tPrijs\t\tVoorraad");
        Console.WriteLine("----------------------------------------------------------");

        var products = vm.GetProducts();

        for (int i = 0; i < products.Count; i++)
        {
            ProductModel? product = products[i];
            // TODO format and align
            Console.WriteLine($"{i + 1}\t\t{product.Name}\t\t{product.Price:C}\t\t{product.Stock}");
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

            var parsed = int.TryParse(userinput, out productcode);
            if (!parsed)
            {
                Console.WriteLine($"\nOngeldige invoer.");
                continue;
            }

            OrderProduct(productcode - 1);

            Console.WriteLine("");

        } while (productcode >= 1);

        Console.WriteLine("\nBedankt voor uw bezoek.");
    }

    private void OrderProduct(int productcode)
    {
        try
        {
            var product = vm.CheckStock(productcode);
            user.PurchaseProduct(product.Price);

            Console.WriteLine($"\nU heeft gekocht: {product}");
            Console.WriteLine($"Uw nieuw balans is: {user.Balance:C}.");
        }
        catch (OutOfStockException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (NotEnoughMoneyException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
