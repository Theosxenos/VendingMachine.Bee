﻿namespace VendingMachine.Bee;
internal class Program
{

    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        var userModel = new UserModel(1_000);
        var viewModel = new VendingMachineViewModel();
        var view = new MainView(viewModel, userModel);
        view.Run();
    }
}