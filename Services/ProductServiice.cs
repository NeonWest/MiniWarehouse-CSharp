using MiniWarehouse_CSharp.Models;

namespace MiniWarehouse_CSharp.Services;

public class ProductService
{
    private readonly List<Product> products = new();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public Product? GetProduct(int id)
    {
        return products.FirstOrDefault(product => product.Id == id);
    }

    public List<Product> GetAllProducts()
    {
        return products;
    }
}