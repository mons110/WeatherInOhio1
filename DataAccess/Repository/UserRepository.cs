using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using DataAccess.Repository;

namespace Domain.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(InternetShopContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public async Task<User?> GetByEmailAndPassword(string email, string password)
        {
            var result = await base.FindByCondition(x => x.Email == email && x.Phonenumber == password);
            if(result == null || result.Count == 0)
                return null;
            return result[0];
        }
    }
}
