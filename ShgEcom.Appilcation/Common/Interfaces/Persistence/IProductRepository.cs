using ShgEcom.Domain.Entites;

namespace ShgEcom.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetActiveProductsAsync();
        Task<Product?> GetByNameAsync(string name);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task SoftDeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<List<Product>> GetProductsByTagAsync(string tag);
        Task<List<Product>> GetOutOfStockProductsAsync();
    }
}
