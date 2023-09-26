using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Infraestructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task Delete(int id)
        {
            Category category  = _dbContext.Category.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Category.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetAll() {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        { 
            return _dbContext.Category.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Category> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            return category;
        }

        
    }
}
