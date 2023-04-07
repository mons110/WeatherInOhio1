using Domain.Models;
using Domain.Interfaces;

namespace WeatherInOhio.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private InternetShopContext _repoContext;
        public RepositoryWrapper(InternetShopContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IUserRepository User => throw new NotImplementedException();

        public void Save()
        {
            _repoContext.SaveChanges();
        }

        Task IRepositoryWrapper.Save()
        {
            throw new NotImplementedException();
        }
    }
}
