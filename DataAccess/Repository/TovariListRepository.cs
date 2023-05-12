using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TovariListRepository : RepositoryBase<TovariList>, ITovariListRepository
    {
        public TovariListRepository(InternetShopContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
