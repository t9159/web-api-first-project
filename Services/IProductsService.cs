using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Services
{
    public interface IProductsService
    {
        public Task<IEnumerable<Product>> GetProducts(int position, int skip, string? name, string? desc,
            int? minPrice, int? maxPrice, int?[] categoriesId);
        public Task<Product> GetProduct(int id);
    }
}
