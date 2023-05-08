namespace VendingMachine.Bee;

public class VendingMachineViewModel
{
    private List<ProductModel> products = new List<ProductModel>()
    {
        new ProductModel { Name = "Boot", Price = 2 },
        new ProductModel { Name = "Citroen", Price = 5 },
        new ProductModel { Name = "Deur", Price = 6.6f },
        new ProductModel { Name = "Egel", Price = 5.33f },
        new ProductModel { Name = "Hooi", Price = 10.03f },
    };

    public List<ProductModel> GetProducts() => products;

    public ProductModel GetProduct(int id) => products[id];
}
