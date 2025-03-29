using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrms.Models
{
    [Table("Attendance")]
    public class Attendancelist
    {
        [Key]
        public int AttendanceId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; }

        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        public virtual Employee Employee { get; set; }

        public List<Attendance> Attendances { get; set; }


    }
}
