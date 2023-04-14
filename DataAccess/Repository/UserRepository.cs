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
    }
}
