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
    };

    public List<ProductModel> GetProducts() => products;

    public ProductModel GetProduct(int id) => products[id];
}
