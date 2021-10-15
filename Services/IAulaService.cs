using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DindinAPI.Models;

namespace DindinAPI.Services
{
    public interface IAulaService
    {
        Task<IEnumerable<Aula>> GetAulas();
        Task<IEnumerable<Aula>> GetAulasByCursoId(int cursoid);
        Task<Aula> GetAula(int id);
        Task CreateAula(Aula curso);
        Task UpdateAula(Aula curso);
        Task DeleteAula(Aula curso);
    }
}
