using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeWebAPI.Data;
using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Controllers
{
    [Route ( "api/[controller]" )]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // solo de lectura
        private readonly EmployeeWebAPIContext _context;

        // Se ha pasado el contexto por el constructor mediante Inyección de dependencias que viene del Startup
        // De aqui se puede acceder al context y del Context se accede a la base de datos física
        public EmployeesController ( EmployeeWebAPIContext context )
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee ( )
        {
            return await _context.Employee.ToListAsync ();
        }

        //public string Get ( )
        //{
        //    return "HELLO WORLD";
        //}


        // GET: api/Employees/5
        [HttpGet ( "{id}" )]
        public async Task<ActionResult<Employee>> GetEmployee ( int id )
        {
            var employee = await _context.Employee.FindAsync ( id );

            if(employee == null)
            {
                return NotFound ();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut ( "{id}" )]
        public async Task<IActionResult> PutEmployee ( int id, Employee employee )
        {
            if(id != employee.EmployeeId)
            {
                return BadRequest ();
            }

            _context.Entry ( employee ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync ();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!EmployeeExists ( id ))
                {
                    return NotFound ();
                }
                else
                {
                    throw;
                }
            }

            return NoContent ();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee ( Employee employee )
        {
            _context.Employee.Add ( employee );
            await _context.SaveChangesAsync ();

            return CreatedAtAction ( "GetEmployee", new { id = employee.EmployeeId }, employee );
        }

        // DELETE: api/Employees/5
        [HttpDelete ( "{id}" )]
        public async Task<ActionResult<Employee>> DeleteEmployee ( int id )
        {
            var employee = await _context.Employee.FindAsync ( id );
            if(employee == null)
            {
                return NotFound ();
            }

            _context.Employee.Remove ( employee );
            await _context.SaveChangesAsync ();

            return employee;
        }

        private bool EmployeeExists ( int id )
        {
            return _context.Employee.Any ( e => e.EmployeeId == id );
        }
    }
}
