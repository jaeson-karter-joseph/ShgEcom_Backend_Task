using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Domain.Entites;

namespace ShgEcom.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = [];

        public Task<Product?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_products.SingleOrDefault(p => p.Id == id && !p.IsDeleted));
        }

        public Task<List<Product>> GetAllAsync()
        {
            return Task.FromResult(_products.Where(p => !p.IsDeleted).ToList());
        }

        public Task<List<Product>> GetActiveProductsAsync()
        {
            return Task.FromResult(_products.Where(p => !p.IsDeleted && p.StockQuantity > 0).ToList());
        }

        public Task<Product?> GetByNameAsync(string name)
        {
            return Task.FromResult(_products.SingleOrDefault(p => p.Name == name && !p.IsDeleted));
        }

        public Task AddAsync(Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
                _products.Add(product);
            }
            return Task.CompletedTask;
        }

        public Task SoftDeleteAsync(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.SoftDelete();
            }
            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            return Task.FromResult(_products.Any(p => p.Id == id && !p.IsDeleted));
        }

        public Task<List<Product>> GetProductsByTagAsync(string tag)
        {
            return Task.FromResult(_products
                .Where(p => p.Tags.Contains(tag) && !p.IsDeleted)
                .ToList());
        }

        public Task<List<Product>> GetOutOfStockProductsAsync()
        {
            return Task.FromResult(_products
                .Where(p => p.StockQuantity == 0 && !p.IsDeleted)
                .ToList());
        }
    }
}
