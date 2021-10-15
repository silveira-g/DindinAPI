using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DindinAPI.Context;
using DindinAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DindinAPI.Services
{
    public class CursosService : ICursoService
    {
        private readonly AppDbContext _context;

        public CursosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Curso>> GetCursos()
        {
            return await _context.Cursos.ToListAsync();
        }
        public async Task<Curso> GetCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            return curso;
        }
        public async Task CreateCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCurso(Curso curso)
        {
            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCurso(Curso curso)
        {
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
        }





    }
}
