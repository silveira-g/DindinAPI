using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DindinAPI.Models;

namespace DindinAPI.Services
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetCursos();
        Task<Curso> GetCurso(int id);
        Task CreateCurso(Curso curso);
        Task UpdateCurso(Curso curso);
        Task DeleteCurso(Curso curso);
    }
}
