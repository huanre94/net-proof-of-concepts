using Grpc.Core;
using InventoryService;
using InventoryService.Models;

namespace InventoryService.Services
{
    public class InventoryAdapter : Inventory.InventoryBase
    {
        private readonly ILogger<InventoryAdapter> _logger;
        readonly IEnumerable<ProductInventory> _products;

        public InventoryAdapter(ILogger<InventoryAdapter> logger)
        {
            _logger = logger;
            _products = [
                new ProductInventory { Id = 1, Stock = 123 },
                new ProductInventory { Id = 2, Stock = 20 },
                new ProductInventory { Id = 3, Stock = 69 },
                new ProductInventory { Id = 4, Stock = 110 }
            ];
        }

        public override async Task<InventoryResponse> CheckCurrentStock(InventoryRequest request, ServerCallContext context)
        {
            var response = _products.Where(_ => _.Id == request.ProductId).FirstOrDefault();

            if (response is null) return await Task.FromResult(new InventoryResponse { ProductId = request.ProductId, Stock = 0 });

            return await Task.FromResult(new InventoryResponse { ProductId = response.Id, Stock = response.Stock });
        }
    }
}
