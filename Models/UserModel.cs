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

    public bool SubtractMoney(float amount)
    {
        if(amount > Balance) return false;

        Balance -= amount;

        return true;
    }

}
