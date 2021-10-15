using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DindinAPI.Context;
using DindinAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DindinAPI.Services
{
    public class AulasService : IAulaService
    {
        private readonly AppDbContext _context;

        public AulasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aula>> GetAulas()
        {
            return await _context.Aulas.ToListAsync();
        }
        public async Task<IEnumerable<Aula>> GetAulasByCursoId(int cursoid)
        {
            IEnumerable<Aula> aulas;
            try
            {
                aulas = await _context.Aulas.Where(a => a.CursoId.Equals(cursoid)).ToListAsync();
                return aulas;
            }
            catch
            {
                return await GetAulas();
            }

        }
        public async Task<Aula> GetAula(int id)
        {
            var aula = await _context.Aulas.FindAsync(id);
            return aula;
        }
        public async Task CreateAula(Aula aula)
        {
            _context.Aulas.Add(aula);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAula(Aula aula)
        {
            _context.Entry(aula).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAula(Aula aula)
        {
            _context.Aulas.Remove(aula);
            await _context.SaveChangesAsync();
        }
    }
}
