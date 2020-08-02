using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PositionJob { get; set; }

        public int Salary { get; set; }
    }
}
