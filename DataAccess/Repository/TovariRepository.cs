using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TovariRepository : RepositoryBase<Tovari>, ITovariRepository
    {
        public TovariRepository(InternetShopContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
