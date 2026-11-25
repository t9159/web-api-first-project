using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Services
{
    public interface IProductsService
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProduct(int id);
    }
}
