using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public class ProductRepository : IProductsRepository
    {
        StoreDBContext _storeDBContext;
        public ProductRepository(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }
        public async Task<IEnumerable<Product>> GetProducts(int position, int skip, string? name, string? desc,
            int? minPrice, int? maxPrice, int?[] categoriesId)
        {
            var query = _storeDBContext.Products.Where(product => (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((name == null) ? (true) : (product.ProductName.Contains(name)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && (categoriesId.Length == 0) ? (true) : (categoriesId.Contains(product.CategoryId))).OrderBy(product => product.Price);
            IEnumerable<Product> products = await query.ToListAsync();
            var total = await query.CountAsync();
            return products;
        }
        public Task<Product> GetProduct(int id)
        {
            Task<Product> product = _storeDBContext.Products.Where(u => u.Id == id).FirstOrDefaultAsync();
            return product;
        }
    }
}
