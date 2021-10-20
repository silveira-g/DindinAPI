using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DindinAPI.Models;
using DindinAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DindinAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        private IAulaService _aulaService;

        public AulasController(IAulaService aulaService)
        {
            _aulaService = aulaService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aula>>> GetAulas()
        {
            try
            {
                var aulas = await _aulaService.GetAulas();
                return Ok(aulas);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }
        [HttpGet("/api/AulasPorCurso/{CursoId:int}", Name = "GetAulasPorCurso")]
        public async Task<ActionResult<IAsyncEnumerable<Aula>>> GetAulasByCursoId(int CursoId)
        {
            try
            {
                
                var aulas = await _aulaService.GetAulasByCursoId(CursoId);
                if(aulas!=null)
                {
                    return Ok(aulas);
                }
                else
                {
                    return NotFound($"Não foi encontrado aulas com Id de Curso= {CursoId}");
                }
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:int}", Name = "GetAula")]
        public async Task<ActionResult<Aula>> GetAula
              (int id)
       {
            try
            {
                var aula = await _aulaService.GetAula(id);
                if (aula == null)
                    return NotFound($"Não existe aula com id= {id}");
                return Ok(aula);
            }
             catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aula aula)
        {
            try
            {
                await _aulaService.CreateAula(aula);
                return CreatedAtRoute(nameof(GetAula), new { id = aula.AulaId }, aula);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aula aula)
        {
            try
            {
                if (aula.AulaId == id)
                {
                    await _aulaService.UpdateAula(aula);
                    return Ok($"Aula com id= {id} foi atualizada com sucesso");
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
                var aula = await _aulaService.GetAula(id);
                if (aula != null)
                {
                    await _aulaService.DeleteAula(aula);
                    return Ok($"Aula de id= {id} removida com sucesso");
                }
                else
                {
                    return NotFound($"Aula com id= {id} não localizada");
                }
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }


    }
}
