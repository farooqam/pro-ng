using System.Threading.Tasks;

namespace SportsStoreApi.DataAccess.Ef
{
    public class ProductRepository : IProductRepository
    {
        private readonly SportsStoreDbContext _dbContext;

        public ProductRepository(SportsStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductAsync(string id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
    }
}