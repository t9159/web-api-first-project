using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetCategories();
    }
}
