using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class Contractor
    {
       [Key]
        public System.Guid ContractorID { get; set; }
        public System.Guid CompanyID { get; set; }
        public System.DateTime ContratDate { get; set; }
        public System.DateTime ContratStartDate { get; set; }
        public System.DateTime ContratEndDate { get; set; }
        public string ContratType { get; set; }
        public Nullable<System.DateTime> ContratRenewDate { get; set; }

        public virtual Company Company { get; set; }
    }
}
