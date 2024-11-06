namespace GraphQLServerExample
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid Id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task Delete(Product product);
    }
}