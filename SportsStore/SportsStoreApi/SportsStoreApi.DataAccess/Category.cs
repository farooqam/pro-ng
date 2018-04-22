using System.Collections.Generic;

namespace SportsStoreApi.DataAccess
{
    public class Category
    {
        public string Name { get; set; }
        public ICollection<ProductCategorization> ProductCategorizations { get; set; }

    }
}