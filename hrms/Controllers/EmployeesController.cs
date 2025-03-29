using hrms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace hrms.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly HrmsDbContext _context = new HrmsDbContext();
        public ActionResult EmployeeForm(int P =0)
        {
            ViewBag.Bt = "Add Employee";
            Employee obj = new Employee();
            if (P > 0)
            {
                var data = (from E in _context.Employees where E.EmployeeId==P select E).ToList();
                obj.Name = data[0].Name;
                obj.Email = data[0].Email;
                obj.Phone = data[0].Name;
                obj.DateOfJoining = data[0].DateOfJoining;
                obj.Department = data[0].Department;
                obj.Salary = data[0].Salary;
                ViewBag.Bt = "Update Employee";

            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult EmployeeInsert(Employee _emp)
        {   
            if(_context.EmployeeId > 0)
            {
                _context.Entry(_emp).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {

                _context.Employees.Add(_emp);

            }
            _context.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }

        public ActionResult DeleteEmployee(int P = 0)
        {
            var data = _context.Employees.Find(P);
            _context.Employees.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }
        
        public ActionResult ShowEmployee()
        {
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

    }
}