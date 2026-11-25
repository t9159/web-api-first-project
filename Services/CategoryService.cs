using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Services
{
    public class CategoryService:ICategoryService
    {
        ICategoriesRepository _categoriesRepository;
        public CategoryService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoriesRepository.GetCategories();
        }
    

    }
}
