using DataAccess.Repository;
using Domain.Interfaces;
using Domain.Models;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class TovariWrapper
    {
        private InternetShopContext _repoContext;
        private ITovariRepository _tovari;
        public ITovariRepository Tovar
        {
            get
            {
                if (_tovari == null)
                {
                    _tovari = new TovariRepository(_repoContext);
                }
                return _tovari;
            }
        }
        public TovariWrapper(InternetShopContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
