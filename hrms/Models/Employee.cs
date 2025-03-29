using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrms.Models
{
	public class Employee
	{
        

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [Column("DateOFJoining")]
        public DateTime DateOfJoining { get; set; } // Ensure this exists
        public string Department { get; set; }
        public decimal Salary { get; set; }


    }
}