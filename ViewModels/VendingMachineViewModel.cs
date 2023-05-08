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

    /// <summary>
    ///     Executes a transaction for the given product, subtracting the product's price from the user's balance and decrementing the product's stock if it is available.
    /// </summary>
    /// <param name="product">The product being purchased.</param>
    /// <returns>
    ///     Returns 1 if the transaction is successful and the product's stock has been decremented. <br/>
    ///     Returns -1 if the user does not have enough money to purchase the product. <br/>
    ///     Returns -2 if the product is out of stock.
    /// </returns>
    public ProductModel CheckStock(int productCode)
    {
        var toPurchaseProduct = products[productCode];

        if(toPurchaseProduct.Stock == 0)
        {
            throw new OutOfStockException(toPurchaseProduct.Name);
        }

        return toPurchaseProduct;
    }
}
