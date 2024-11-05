using ProductService.Models;

namespace ProductService.Services
{
    public interface IProductService
    {
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
    }
}
