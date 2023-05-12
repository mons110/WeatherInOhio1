using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class TovariService : ITovariService
    {
        private ITovariWrapper _repositoryWrapper;
        public TovariService(ITovariRepository repositoryWrapper)
        {
            _repositoryWrapper = (ITovariWrapper)repositoryWrapper;
        }
        public async Task<List<Tovari>> GetAll()
        {
            return await _repositoryWrapper.Tovari.FindAll();
        }
        public async Task<Tovari> GetById(int id)
        {
            var tova = await _repositoryWrapper.Tovari
            .FindByCondition(x => x.Id == id);
            return tova.First();
        }
        public async Task Create(Tovari model)
        {
            await _repositoryWrapper.Tovari.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Tovari model)
        {
            _repositoryWrapper.Tovari.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var tova = await _repositoryWrapper.Tovari
            .FindByCondition(x => x.Id == id);
            _repositoryWrapper.Tovari.Delete(tova.First());
            _repositoryWrapper.Save();
        }

        Task<Tovari> ITovariService.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
