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
        int productAmount = 0;
        int productCode = 0;

        // Evt. ook naam?
        Console.WriteLine("\nMaak uw keuze ahv de productcode.");

        // TODO Error Handling
        var userinput = Console.ReadLine();

        var parsed = int.TryParse(userinput, out productCode);
        if (!parsed)
        {
            Console.WriteLine($"\nOngeldige product keuze.");
            return;
        }

        // The list is 0-based, but the UI listing is not
        productCode--;

        Console.WriteLine("Hoeveel wilt u kopen? Voer getal van 1-9 in, of druk op Enter. Druk op Escape om te stoppen.");

        var userKeyInput = Console.ReadKey();

        int.TryParse(userKeyInput.KeyChar.ToString(), out int parsedUserInput);

        if (parsedUserInput > 0 && parsedUserInput < 10)
        {
            productAmount = parsedUserInput;
        }
        else if (userKeyInput.Key == ConsoleKey.Enter)
        {
            productAmount = 1;
        }
        else if (userKeyInput.Key == ConsoleKey.Escape)
        {
            productCode = -1;
            return;
        }

        if (!OrderProductConfirmation(productCode, productAmount))
        {
            if (!NewOrderCheck())
                return;

            ClearView();
        }

        OrderProduct(productCode, productAmount);

        if (!NewOrderCheck())
            return;

        ClearView();
    }

    private bool NewOrderCheck()
    {
        Console.WriteLine("Nieuwe bestelling? [Y/N]");
        var userKeyInput = Console.ReadKey();

        if (userKeyInput.Key == ConsoleKey.Y)
        {
            return true;
        }
        else if (userKeyInput.Key == ConsoleKey.N)
        {
            Console.WriteLine("");
            Console.WriteLine("\nBedankt voor uw bezoek.");
            return false;
        }

        return false;
    }

    private bool OrderProductConfirmation(int productcode, int amountbought)
    {
        var totalPrice = vm.GetOffer(productcode, amountbought);
        var productName = vm.GetProduct(productcode).Name;

        Console.WriteLine($"\nU wilt {amountbought} van {productName} kopen voor {totalPrice:C}. Gaat u akkoord? [Y/N]");
        var userKeyInput = Console.ReadKey();
        
        // For readability
        Console.WriteLine();

        if(userKeyInput.Key == ConsoleKey.Y)
        {
            return true;
        }
        else if(userKeyInput.Key == ConsoleKey.N)
        {
            return false;
        }

        Console.WriteLine("Invoer is niet Y of N.");

        return false;
    }

    private void OrderProduct(int productcode, int amountbought)
    {
        try
        {
            var product = vm.CheckStock(productcode, amountbought);
            user.PurchaseProduct(product.Price);

            Console.WriteLine($"\nU heeft gekocht: {product}");
            Console.WriteLine($"Uw nieuw balans is: {user.Balance:C}.");
        }
        catch (NotEnoughInStockException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (NotEnoughMoneyException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ClearView()
    {
        Console.Clear();
        ShowMenu();
    }
}
