using Grpc.Net.Client;
using Grpc.Net.ClientFactory;
using InventoryService;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductAdapter : IProductService
    {
        readonly IEnumerable<Product> products;


        public ProductAdapter()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10 },
                new Product { Id = 2, Name = "Product 2", Price = 20 },
                new Product { Id = 3, Name = "Product 3", Price = 30 },
                new Product { Id = 4, Name = "Product 4", Price = 40 },
                new Product { Id = 5, Name = "Product 5", Price = 50 }
            };
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var response = await Task.FromResult(products);

            using var channel = GrpcChannel.ForAddress("http://localhost:5046");
            var client = new Inventory.InventoryClient(channel);

            for (int i = 0; i < products.Count(); i++)
            {
                var res = client.CheckCurrentStock(new InventoryRequest { ProductId = products.ElementAt(i).Id });
                products.ElementAt(i).Stock = res.Stock;
            }

            return response;
        }

        public async Task<Product> GetById(int id)
        {
            var response = products.Where(x => x.Id == id).FirstOrDefault();

            var channel = GrpcChannel.ForAddress("https://localhost:7123");
            var client = new Inventory.InventoryClient(channel);
            var res = client.CheckCurrentStock(new InventoryRequest { ProductId = id });

            res.Stock = res.Stock;

            return response;
        }
    }
}
