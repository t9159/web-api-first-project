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
        public async Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> products= await _storeDBContext.Products.ToListAsync();
            return products;
        }
        public Task<Product> GetProduct(int id)
        {
            Task<Product> product = _storeDBContext.Products.Where(u => u.Id == id).FirstOrDefaultAsync();
            return product;
        }
    }
}
