using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models
{
    public class Employee
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }
    }
}
