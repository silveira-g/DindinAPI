using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DindinAPI.Models
{
    public class Aula
    {
        public int AulaId { get; set; }
        [Required]
        public string AulaDescricao { get; set; }
        [Required]
        public string AulaLink { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
    public class Curso
    {
        public int CursoId { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Professor { get; set; }
        [Required]
        public string ImagemCapa { get; set; }
        [Required]
        public string CursoDescricao { get; set; }
        [Required]
        public ICollection<Aula> Aula { get; set; } 
    }
}
