using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hrms.Models
{
    public partial class HrmsDbContext : DbContext
    {
        public HrmsDbContext() : base("abc") // Connection string name
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Payroll> Payrolls { get; set; }
        public int EmployeeId { get; internal set; }

        internal void Add(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
