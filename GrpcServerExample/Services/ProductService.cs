using Grpc.Core;

namespace GrpcServerExample.Services
{
    public class ProductService : Products.ProductsBase
    {
        public override Task<ProductResponse> GetAll(ProductRequest request, ServerCallContext context)
        {
            return new Task<ProductResponse>(() => new ProductResponse
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description of Product 1",
                Price = "100"
            });
        }
    }
}
