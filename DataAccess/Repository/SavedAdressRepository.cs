using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SavedAdressRepository : RepositoryBase<SavedAdress>, ISavedAdressRepository
    {
        public SavedAdressRepository(InternetShopContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
