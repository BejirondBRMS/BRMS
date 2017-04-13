using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class vwEmployeePersons
    {
        [Key]
        public Guid EmployeeID { get; set; }
        public string FullName { get; set; }
    }
}
