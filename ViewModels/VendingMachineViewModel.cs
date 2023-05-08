namespace VendingMachine.Bee;

public class VendingMachineViewModel
{
    private List<ProductModel> products = new List<ProductModel>()
    {
        new ProductModel { Name = "Boot", Price = 2, Stock = 2 },
        new ProductModel { Name = "Citroen", Price = 5, Stock = 12 },
        new ProductModel { Name = "Deur", Price = 6.6f, Stock = 23 },
        new ProductModel { Name = "Egel", Price = 5.33f, Stock = 0 },
        new ProductModel { Name = "Hooi", Price = 10.03f, Stock = 6 },
        new ProductModel { Name = "Micorosft C# Certificaat", Price = 10_000_000, Stock = 1337 },
    };

    public List<ProductModel> GetProducts() => products;

    public ProductModel GetProduct(int id) => products[id];

    public float GetOffer(int productcode, int amountbought) => GetProduct(productcode).Price * amountbought;


    /// <summary>
    ///     Executes a transaction for the given product, subtracting the product's price from the user's balance and decrementing the product's stock if it is available.
    /// </summary>
    /// <param name="product">The product being purchased.</param>
    /// <returns></returns>
    public ProductModel CheckStock(int productCode, int amountBought)
    {
        var toPurchaseProduct = GetProduct(productCode);

        if(toPurchaseProduct.Stock < amountBought)
        {
            throw new NotEnoughInStockException(amountBought, toPurchaseProduct.Name);
        }

        return toPurchaseProduct;
    }

    public void ReduceStock(int productCode, int amountBought)
    {
        var toPurchaseProduct = GetProduct(productCode);
        toPurchaseProduct.Stock -= amountBought;
    }

}
