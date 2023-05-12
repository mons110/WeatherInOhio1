using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITovariListService
    {
        Task<List<TovariList>> GetAll();
        Task<TovariList> GetById(int id);
        Task Create(TovariList model);
        Task Update(TovariList model);
        Task<TovariList> Delete(int id);
    }
}
