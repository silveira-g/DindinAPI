using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DindinAPI.Models
{
    public class Aula
    {
        public int AulaId { get; set; }
        [Required]
        public string AulaDescricao { get; set; }
        [Required]
        public string AulaTitulo { get; set; }
        [Required]
        public string AulaLink { get; set; }

        public int CursoId { get; set; }
        [JsonIgnore]
        public Curso Cursos { get; set; }
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

        public List<Aula> Aula { get; set; } 
    }

   
}
