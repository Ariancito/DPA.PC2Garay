using DPA.Store.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task Delete(int id);
        public Task<Category> GetById(int id);
        public Task<Category> Insert(Category category);
        

    }
}
