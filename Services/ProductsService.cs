using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repositories;

namespace Services
{
    public class ProductsService:IProductsService
    {
        IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productsRepository.GetProducts();
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _productsRepository.GetProduct(id);
        }
    }
}
