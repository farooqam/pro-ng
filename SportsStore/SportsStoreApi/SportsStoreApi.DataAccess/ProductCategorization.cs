namespace SportsStoreApi.DataAccess
{
    public class ProductCategorization
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}