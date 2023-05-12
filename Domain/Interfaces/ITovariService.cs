using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITovariService
    {
        Task<List<Tovari>> GetAll();
        Task<Tovari> GetById(int id);
        Task Create(Tovari model);
        Task Update(Tovari model);
        Task<Tovari> Delete(int id);
    }
}
