using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CategoriesRepository:ICategoriesRepository
    {
        StoreDBContext _context;
        public CategoriesRepository(StoreDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            return categories;
        }
    }

}
