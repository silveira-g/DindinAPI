using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DindinAPI.Models;
using DindinAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DindinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Curso>>> GetCursos()
        {
            try
            {
                var cursos = await _cursoService.GetCursos();
                return Ok(cursos);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:int}", Name ="GetCurso")]
        public async Task<ActionResult<Curso>> GetCurso
            (int id)
        {
            try
            {
                var curso = await _cursoService.GetCurso(id);
                if (curso == null)
                    return NotFound($"Não existe curso com id= {id}");
                return Ok(curso);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Curso curso)
        {
            try
            {
                await _cursoService.CreateCurso(curso);
                return CreatedAtRoute(nameof(GetCurso), new { id = curso.CursoId }, curso);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        } 

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Curso curso)
        {
            try
            {
                if (curso.CursoId== id)
                {
                    await _cursoService.UpdateCurso(curso);
                    return Ok($"Curso com id= {id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var curso = await _cursoService.GetCurso(id);
                if (curso != null)
                {
                    await _cursoService.DeleteCurso(curso);
                    return Ok($"Curso de id= {id} removido com sucesso");
                }
                else
                {
                    return NotFound($"Curso com id= {id} não localizado");
                }
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }



    }
}
