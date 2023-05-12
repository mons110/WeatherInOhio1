using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISavedAdressService
    {
        Task<List<SavedAdress>> GetAll();
        Task<SavedAdress> GetById(int id);
        Task Create(SavedAdress model);
        Task Update(SavedAdress model);
        Task<SavedAdress> Delete(int id);
    }
}
