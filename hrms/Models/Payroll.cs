using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrms.Models
{

[Table("Payroll")]
	public class Payroll
	{
		[Key]
		public int PayrollId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }


        [Required]
        [Display (Name = "Basic Salary")]
        public Decimal BasicSalary { get; set; }


        [Display(Name = "Allowances")]
        public Decimal Allowances { get; set; } = 0;

        [Display(Name = "Deductions")]
        public Decimal Deductions { get; set; } = 0;


        [Display(Name = "NetSalary")]
        public Decimal NetSalary => (BasicSalary + Allowances) - Deductions;

        [Required]
        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
    }
}