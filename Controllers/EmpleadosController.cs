using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppEncuestasAPI.Data;
using AppEncuestasAPI.Models.Empleados;

namespace AppEncuestasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly AppEncuestasDbContext _context;
        private readonly IMapper mapper;
        public EmpleadosController(AppEncuestasDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper=mapper;
        }


        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoReadOnlyDTO>>> GetEmpleados()
        {
            if (_context.Encuestas == null)
            {
                return NotFound();
            }
            var empleados = await _context.Empleados.ToListAsync();
            foreach (Empleado empleado in empleados) {
                //encuesta.AtendidoPor = await _context.EmpleadosEncuesta.FindAsync(encuesta.EmpleadoId);
            }
            var empleadosDTO=mapper.Map<IEnumerable<EmpleadoReadOnlyDTO>> (empleados);
            return Ok(empleadosDTO);
        }

        // GET: api/Encuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            // var empleadoDTO=mapper.Map<EmpleadoReadOnlyDTO>(empleado);

            return Ok(empleado);
        }
        private async Task<bool> EmpleadoExists(int id)
        {
            return await _context.Empleados.AnyAsync(e => e.Id == id);
        }
    }
}
