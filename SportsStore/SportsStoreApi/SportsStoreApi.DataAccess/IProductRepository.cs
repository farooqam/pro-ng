using System.Threading.Tasks;

namespace SportsStoreApi.DataAccess
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(string id);
    }
}