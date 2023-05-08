namespace VendingMachine.Bee;

/// <summary>
/// Exception that is thrown when the user does not have enough money to purchase a product.
/// </summary>
public class NotEnoughMoneyException : Exception
{
    public NotEnoughMoneyException(float missingAmount)
        : base($"U heeft niet genoeg geld om het product te kopen. U mist: {missingAmount:C}")
    {
    }
}
