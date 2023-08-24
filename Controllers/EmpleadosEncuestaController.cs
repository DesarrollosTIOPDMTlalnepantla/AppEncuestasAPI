using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppEncuestasAPI.Data;
using AppEncuestasAPI.Models.EmpleadosEncuesta;

namespace AppEncuestasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosEncuestaController : ControllerBase
    {
        private readonly AppEncuestasDbContext _context;
        private readonly IMapper mapper;

        public EmpleadosEncuestaController(AppEncuestasDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper=mapper;
        }

        // GET: api/EmpleadosEncuesta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoEncuestaReadOnlyDTO>>> GetEmpleadosEncuesta()
        {
          if (_context.EmpleadosEncuesta == null)
          {
              return NotFound();
          }
            var empleadosEncuesta=await _context.EmpleadosEncuesta.ToListAsync();
            var empleadosEncuestaDTOs=mapper.Map<IEnumerable<EmpleadoEncuestaReadOnlyDTO>>(empleadosEncuesta);
            return Ok(empleadosEncuestaDTOs);
        }

        // GET: api/EmpleadoEncuesta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoEncuesta>> GetEmpleadoEncuesta(int id)
        {
          if (_context.EmpleadosEncuesta == null)
          {
              return NotFound();
          }
            var empleadoEncuesta = await _context.EmpleadosEncuesta.FindAsync(id);

            if (empleadoEncuesta == null)
            {
                return NotFound();
            }
            return Ok(empleadoEncuesta);
        }

        // PUT: api/Contrataciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleadoEncuesta(int id, EmpleadoEncuestaActualizarDTO empleadoEncuestaDTO)
        {
            if (id != empleadoEncuestaDTO.Id)
            {
                return BadRequest();
            }

            var empleadoEncuesta=await _context.EmpleadosEncuesta.FindAsync(id);
            if(empleadoEncuesta == null)
            {
                return NotFound();
            }
            mapper.Map(empleadoEncuestaDTO, empleadoEncuesta);
            _context.Entry(empleadoEncuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoEncuestaExists(id))
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

        // POST: api/EmpleadosEncuesta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpleadoEncuestaCrearDTO>> PostEmpleadoEncuesta(EmpleadoEncuestaCrearDTO empleadoEncuestaDTO)
        {
          if (_context.EmpleadosEncuesta == null)
          {
              return Problem("Entity set 'TramitesDbContext.Contrataciones'  is null.");
          }
            var empleadoEncuesta=mapper.Map<EmpleadoEncuesta>(empleadoEncuestaDTO);
            _context.EmpleadosEncuesta.Add(empleadoEncuesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleadoEncuesta", new { id = empleadoEncuesta.Id }, empleadoEncuesta);
        }

        // DELETE: api/Contrataciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleadoEncuesta(int id)
        {
            if (_context.EmpleadosEncuesta == null)
            {
                return NotFound();
            }
            var empleadoEncuesta = await _context.EmpleadosEncuesta.FindAsync(id);
            if (empleadoEncuesta == null)
            {
                return NotFound();
            }

            _context.EmpleadosEncuesta.Remove(empleadoEncuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoEncuestaExists(int id)
        {
            return (_context.EmpleadosEncuesta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
