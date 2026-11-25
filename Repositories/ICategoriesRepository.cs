using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repositories
{
    public interface ICategoriesRepository
    {
        public Task<IEnumerable<Category>> GetCategories();
    }
}
