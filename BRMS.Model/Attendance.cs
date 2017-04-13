using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class Attendance
    {
        [Key]
        public System.Guid AttendanceID { get; set; }
        public System.DateTime WorkDate { get; set; }
        public System.Guid EmployeeId { get; set; }
        public System.TimeSpan InTime { get; set; }
        public System.TimeSpan OutTime { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
