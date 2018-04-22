using SportsStoreApi.DataAccess;

namespace SportsStore.DataAccess.Ef
{
    public class ProductCategorization
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}