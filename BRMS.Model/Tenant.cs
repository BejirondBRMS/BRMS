using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class Tenant
    {
        public Tenant()
        {
            this.ContratSummeries = new HashSet<ContratSummery>();
            this.Expenses = new HashSet<Expense>();
            this.Parkings = new HashSet<Parking>();
        }
        [Key]
        public System.Guid TenantID { get; set; }
        public Nullable<System.Guid> PersonID { get; set; }
        public Nullable<System.Guid> CompanyID { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<ContratSummery> ContratSummeries { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
        public virtual Person Person { get; set; }
    }
}
