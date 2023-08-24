using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppEncuestasAPI.Data;
using AppEncuestasAPI.Models.Encuestas;

namespace AppEncuestasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestasController : ControllerBase
    {
        private readonly AppEncuestasDbContext _context;
        private readonly IMapper mapper;
        public EncuestasController(AppEncuestasDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper=mapper;
        }


        // GET: api/Encuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EncuestaReadOnlyDTO>>> GetEncuestas()
        {
            if (_context.Encuestas == null)
            {
                return NotFound();
            }
            var encuestas= await _context.Encuestas
            // .Include(e => e.AtendidoPor)
            .ToListAsync();
            // foreach (Encuesta encuesta in encuestas) {
                //encuesta.AtendidoPor = await _context.EmpleadosEncuesta.FindAsync(encuesta.EmpleadoId);
            // }
            var encuestasDTO=mapper.Map<IEnumerable<EncuestaReadOnlyDTO>> (encuestas);
            return Ok(encuestasDTO);
        }

        // GET: api/Encuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EncuestaReadOnlyDTO>> GetEncuesta(int id)
        {
          if (_context.Encuestas == null)
          {
              return NotFound();
          }
            var encuesta = await _context.Encuestas.FindAsync(id);

            if (encuesta == null)
            {
                return NotFound();
            }

            var encuestaDTO=mapper.Map<EncuestaReadOnlyDTO>(encuesta);

            return Ok(encuestaDTO);
        }

        // PUT: api/Encuesta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncuesta(int id, EncuestaActualizarDTO encuestaDTO)
        {
            if (id != encuestaDTO.EncuestaId)
            {
                return BadRequest();
            }

            var encuesta= await _context.Encuestas.FindAsync(id);

            if (encuesta == null)
            {
                return NotFound();
            }

            mapper.Map(encuestaDTO, encuesta);            
            
            _context.Entry(encuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EncuestaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Encuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EncuestaCrearDTO>> PostEncuesta(EncuestaCrearDTO encuestaDTO)
        {
          if (_context.Encuestas == null)
          {
              return Problem("Entity set 'EncuestasDbContext.Encuestas'  is null.");
          }
            var encuesta=mapper.Map<Encuesta>(encuestaDTO);
            encuesta.Ingresada = DateTime.Now;
            await _context.Encuestas.AddAsync(encuesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncuesta", new { id = encuesta.Id }, encuesta);
        }

        // DELETE: api/Certificados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncuesta(int id)
        {
            if (_context.Encuestas == null)
            {
                return NotFound();
            }
            var encuesta = await _context.Encuestas.FindAsync(id);
            if (encuesta == null)
            {
                return NotFound();
            }

            _context.Encuestas.Remove(encuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> EncuestaExists(int id)
        {
            return await _context.Encuestas.AnyAsync(e => e.Id == id);
        }
    }
}
