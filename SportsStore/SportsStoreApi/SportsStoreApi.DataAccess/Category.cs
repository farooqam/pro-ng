using System.Collections.Generic;
using SportsStore.DataAccess.Ef;

namespace SportsStoreApi.DataAccess
{
    public class Category
    {
        public string Name { get; set; }
        public ICollection<ProductCategorization> ProductCategorizations { get; set; }

    }
}