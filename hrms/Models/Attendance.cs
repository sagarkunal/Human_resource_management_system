using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrms.Models
{
        [Table("Attendance")]
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }  

        public DateTime Date { get; set; }
        public string Status { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

       
        public virtual Employee Employee { get; set; }
    }

}
