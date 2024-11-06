using Bogus;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServerExample
{
    public class GQLContext : DbContext
    {
        public string DbPath { get; }

        public GQLContext()
        {
        }

        public GQLContext(DbContextOptions options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "products.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            var products = GenerateProducts(10);
            modelBuilder.Entity<Product>().HasData(products);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

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
