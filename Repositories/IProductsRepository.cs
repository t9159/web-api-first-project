using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repositories
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProduct(int id);

    }
}
