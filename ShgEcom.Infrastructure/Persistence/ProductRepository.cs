using MongoDB.Bson;
using MongoDB.Driver;
using ShgEcom.Application.Common.Interfaces.Persistence;
using ShgEcom.Domain.Entites;
using ShgEcom.Infrastructure.Persistence.DbContext;

namespace ShgEcom.Infrastructure.Persistence
{
    public class ProductRepository(MongoDbContext context) : IProductRepository
    {
        private static readonly List<Product> _products = [];

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var product = await context.Products.Find(p => p.Id == id && !p.IsDeleted).FirstOrDefaultAsync();
            //return Task.FromResult(_products.SingleOrDefault(p => p.Id == id && !p.IsDeleted));
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await context.Products.Find(p => !p.IsDeleted).ToListAsync();
            //return Task.FromResult(_products.Where(p => !p.IsDeleted).ToList());
        }

        public async Task<List<Product>> GetActiveProductsAsync()
        {
            var products = await context.Products.Find(p => !p.IsDeleted && p.StockQuantity > 0).ToListAsync();
            return products;
            //return Task.FromResult(_products.Where(p => !p.IsDeleted && p.StockQuantity > 0).ToList());
        }

        public Task<Product?> GetByNameAsync(string name)
        {
            return Task.FromResult(_products.SingleOrDefault(p => p.Name == name && !p.IsDeleted));
        }

        public Task AddAsync(Product product)
        {
            _products.Add(product);
            context.Products.InsertOneAsync(product);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
                _products.Add(product);
            }
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            var update = Builders<Product>.Update
              .Set(p => p.Name, product.Name)
              .Set(p => p.Description, product.Description)
              .Set(p => p.Price, product.Price)
              .Set(p => p.StockQuantity, product.StockQuantity)
              .Set(p => p.Status, product.Status)
              .Set(p => p.Tags, product.Tags)
              .Set(p => p.UpdatedAt, DateTime.UtcNow);

            await context.Products.UpdateOneAsync(filter, update);
            //return Task.CompletedTask;
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var update = Builders<Product>.Update
              .Set(p => p.IsDeleted, true)
              .Set(p => p.UpdatedAt, DateTime.UtcNow);
            await context.Products.UpdateOneAsync(filter, update);
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            return Task.FromResult(_products.Any(p => p.Id == id && !p.IsDeleted));
        }

        public async Task<List<Product>> GetProductsByTagAsync(string tag)
        {
            var products = await context.Products.Find(p => p.Tags.Contains(tag) && !p.IsDeleted).ToListAsync();
            return products;
        }

        public Task<List<Product>> GetOutOfStockProductsAsync()
        {
            return Task.FromResult(_products
                .Where(p => p.StockQuantity == 0 && !p.IsDeleted)
                .ToList());
        }
    }
}
