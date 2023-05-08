namespace VendingMachine.Bee;

internal class NotEnoughInStockException : Exception
{
    public NotEnoughInStockException(int amountMissing, string productName = "producten") :base($"U wilt {amountMissing} meer {productName} kopen dan dat er op voorraad is.")
    {
        
    }
}
