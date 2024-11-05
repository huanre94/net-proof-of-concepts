namespace GraphQLServerExample
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task Add(Product product);
    }
}