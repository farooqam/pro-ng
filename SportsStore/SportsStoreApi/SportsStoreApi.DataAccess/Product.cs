﻿using System.Collections;
using System.Collections.Generic;

namespace SportsStoreApi.DataAccess
{
    public class Product
    {
        public string ProductId { get; set; }
        public ICollection<ProductCategorization> ProductCategorizations { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }
    }
}