using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Data
{
    // clase que hereda del DbContext sirve para hacer tablas de BD
    public class EmployeeWebAPIContext : DbContext
    {
        // contiene todas las tablas de la aplicación
        public EmployeeWebAPIContext (DbContextOptions<EmployeeWebAPIContext> options)
            : base(options)
        {
        }

        // duplicado de tabla de Base de datos en código
        public DbSet<EmployeeWebAPI.Models.Employee> Employee { get; set; }

        // Method join DB with code
        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Employee> ().ToTable ( "Employee" );
        }
    }
}
