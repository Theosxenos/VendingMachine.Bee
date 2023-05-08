namespace VendingMachine.Bee;

public class UserModel
{
    public float Balance { get; private set; }

    public UserModel(float startingbalance)
    {
        Balance = startingbalance;
    }

    public void AddMoney(float amount) 
    { 
        Balance += amount;
    }

    public void PurchaseProduct(float purchasePrice)
    {
        if(purchasePrice > Balance)
        {
            throw new NotEnoughMoneyException(purchasePrice - Balance);
        }

        Balance -= purchasePrice;
    }
}
