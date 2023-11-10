using ShoppingApplication.Models;

namespace ShoppingApplication.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product Add(Product product);
    }
}
