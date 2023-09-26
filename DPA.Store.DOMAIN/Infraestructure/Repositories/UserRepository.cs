using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    { 
 
        private readonly StoreDbContext _dbContext;

        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {

            var user = await _dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(user != null)
            {
                _dbContext.User.Remove(user);
                var respuesta = await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
            
        }

 

        public async Task<User> Insert(User user)
        {
            await _dbContext.User.AddAsync(user);
            _dbContext.SaveChanges();
            return user;
        }

        public async Task<bool> SignIn(string email, string clave)
        {
            var respuesta = await _dbContext.User.Where(x => x.Password == clave && x.Email == email).FirstOrDefaultAsync();
            if(respuesta == null)
            {
                return false;

            }
            else
            {
                return true;
            }

        }
    }
}
