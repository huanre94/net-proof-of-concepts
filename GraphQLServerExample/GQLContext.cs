using Bogus;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServerExample
{
    public class GQLContext : DbContext
    {
        public GQLContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            var products = GenerateProducts(10);
            modelBuilder.Entity<Product>().HasData(products);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("ProductDB");
        //}

        public DbSet<Product> Products { get; set; }


        private List<Product> GenerateProducts(int count)
        {
            var productFaker = new Faker<Product>()
                .RuleFor(b => b.Id, f => f.Random.Guid())
                .RuleFor(b => b.Name, f => f.Lorem.Text())
                .RuleFor(b => b.Price, f => f.Random.Decimal());

            return productFaker.Generate(count);
        }
    }
}
