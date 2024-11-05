
using Microsoft.EntityFrameworkCore;

namespace GraphQLServerExample
{
    public class ProductRepository : IProductRepository
    {
        readonly GQLContext _context;

        public ProductRepository(GQLContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            var added = await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var response = await _context.Products.ToListAsync();
            return response;
        }

    }
}
