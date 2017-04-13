using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class vwInspections
    {
        [Key]
        public Guid InspectionID { get; set; }
        public DateTime InspectionDate { get; set; }
        public Guid PropertyID { get; set; }
        public string DamagedItem { get; set; }
        public string InspectedBy { get; set; }
        public string Property { get; set; }
    }
}
