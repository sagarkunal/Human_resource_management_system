using hrms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace hrms.Controllers
{
    public class PayrollController : Controller
    {

        private readonly HrmsDbContext _context = new HrmsDbContext();


        public ActionResult Index()
        {
            var payrollList = _context.Payrolls.Include(p => p.Employee).ToList();
            return View(payrollList);
        }


        public ActionResult Create()
        {
            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                _context.Payrolls.Add(payroll);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name", payroll.EmployeeId);
            return View(payroll);
        }



        public ActionResult Edit(int id)
        {
            var payroll = _context.Payrolls.Find(id);
            if (payroll == null)
            {
                return HttpNotFound();
            }

            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name", payroll.EmployeeId);
            return View(payroll);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                var existingPayroll = _context.Payrolls.Find(payroll.PayrollId);
                if (existingPayroll != null)
                {
                    existingPayroll.EmployeeId = payroll.EmployeeId;
                    existingPayroll.BasicSalary = payroll.BasicSalary;
                    existingPayroll.Allowances = payroll.Allowances;
                    existingPayroll.Deductions = payroll.Deductions;
                    existingPayroll.PaymentDate = payroll.PaymentDate;

                    _context.Entry(existingPayroll).State = EntityState.Modified;
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name", payroll.EmployeeId);
            return View(payroll);
        }




        public ActionResult Delete(int id)
        {
            var payroll = _context.Payrolls.Find(id);
            if(payroll == null)
            {
                return HttpNotFound();

            }
            return View(payroll);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var payroll = _context.Payrolls.Find(id);
            if (payroll != null)
            {
                _context.Payrolls.Remove(payroll);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}