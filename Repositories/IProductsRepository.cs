using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repositories
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Product>> GetProducts(int position, int skip, string? name, string? desc,
            int? minPrice, int? maxPrice, int?[] categoriesId);
        public Task<Product> GetProduct(int id);

    }
}
