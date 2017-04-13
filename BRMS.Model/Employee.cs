using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class Employee
    {
        public Employee()
        {
            this.Attendances = new HashSet<Attendance>();
           // this.Employee1 = new HashSet<Employee>();
            //this.Inspections = new HashSet<Inspection>();
        }
       [Key]
        public System.Guid EmployeeID { get; set; }
        public System.DateTime HireDate { get; set; }
        public string Position { get; set; }
        public string EmploymentType { get; set; }
        public string PersonID { get; set; }
        public Nullable<System.Guid> ManagerID { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
       // public virtual ICollection<Employee> Employee1 { get; set; }        
       // public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
