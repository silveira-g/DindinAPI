using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DindinAPI.Models
{
    public class Aula
    {
        public int AulaId { get; set; }
        public string AulaDescricao { get; set; }
        public string AulaLink { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
    public class Curso
    {
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public string Professor { get; set; }
        public string ImagemCapa { get; set; }
        public string CursoDescricao { get; set; }
        public ICollection<Aula> Aula { get; set; } 
    }
}
