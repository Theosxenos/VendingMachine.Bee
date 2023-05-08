namespace VendingMachine.Bee;

/// <summary>
/// Exception that is thrown when a product is out of stock.
/// </summary>
public class OutOfStockException : Exception
{
    public OutOfStockException(string productName)
        : base($"Het product {productName} is niet meer op voorraad.")
    {
    }
}
