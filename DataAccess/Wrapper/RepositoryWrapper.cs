using Domain.Interfaces;
using Domain.Repository;
using DataAccess.Repository;
using Domain.Models;
using Domain.Interfaces;


namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private InternetShopContext _repoContext;
        public IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    UserRepository userRepository2 = new UserRepository(_repoContext);
                    _user = (IUserRepository?)userRepository2;
                }
                return _user;
            }
        }
        public RepositoryWrapper(InternetShopContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
