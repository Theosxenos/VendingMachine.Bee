namespace VendingMachine.Bee;
internal class Program
{

    private static void Main(string[] args)
    {
        var viewmodel = new VendingMachineViewModel();
        var view = new MainView(viewmodel);
        view.Run();
    }
}