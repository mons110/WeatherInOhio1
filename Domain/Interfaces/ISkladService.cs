using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISkladService
    {
        Task<List<Sklad>> GetAll();
        Task<Sklad> GetById(int id);
        Task Create(Sklad model);
        Task Update(Sklad model);
        Task<Sklad> Delete(int id);
    }
}
