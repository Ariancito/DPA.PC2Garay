using DPA.Store.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> Insert(User user);
        public Task<bool> SignIn(string email, string clave);
        public Task<bool> Delete(int id);
    }
}
