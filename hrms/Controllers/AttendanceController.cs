using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using hrms.Models;

namespace hrms.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly HrmsDbContext _context = new HrmsDbContext(); // Database context

        // 1️⃣ GET: Attendance List
        public ActionResult Index()
        {
            var attendanceList = _context.Attendance.Include(a => a.Employee).ToList();
            return View(attendanceList);
        }

        // 2️⃣ GET: Mark Attendance Form
        public ActionResult MarkAttendance()
        {
            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name");
            return View();
        }

        public ActionResult Edit(int id)
        {
            var attendance = _context.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }

            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name", attendance.EmployeeId);
            return View(attendance);
        }

        // 3️⃣ POST: Save Attendance Record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MarkAttendance(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Attendance.Add(attendance);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name", attendance.EmployeeId);
            return View(attendance);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                var existingAttendance = _context.Attendance.Find(attendance.AttendanceId);

                if(existingAttendance != null)
                {
                    existingAttendance.EmployeeId = attendance.EmployeeId;
                    existingAttendance.Date = attendance.Date;
                    existingAttendance.Status = attendance.Status;
                    existingAttendance.CheckInTime = attendance.CheckInTime;
                    existingAttendance.CheckOutTime = attendance.CheckOutTime;

                    _context.Entry(existingAttendance).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name", attendance.EmployeeId);
            return RedirectToAction("Index");
        }

   
        public ActionResult Delete(int id)
        {
            var attendance = _context.Attendance.Find(id);
            if (attendance == null)
            {

                return HttpNotFound();
            }

            return View(attendance);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var attendance = _context.Attendance.Find(id);

            if(attendance != null)
            {
                _context.Attendance.Remove(attendance);
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");

        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }
    }
}
