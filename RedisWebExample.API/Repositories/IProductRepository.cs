using RedisWebExample.API.Models;

namespace RedisWebExample.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product);

    }
}
