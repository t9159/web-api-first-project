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
        public async Task<IEnumerable<Product>> GetProducts(int position, int skip, string? name, string? desc,
            int? minPrice, int? maxPrice, int?[] categoriesId)
        {
            return await _productsRepository.GetProducts(position, skip, name, desc, minPrice, maxPrice, categoriesId);
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _productsRepository.GetProduct(id);
        }
    }
}
