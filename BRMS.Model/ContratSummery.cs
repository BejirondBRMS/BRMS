using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class ContratSummery
    {
        public ContratSummery()
        {
            this.ContratDetails = new HashSet<ContratDetail>();
        }
        [Key]
        public System.Guid ContratID { get; set; }
        public string Contrattype { get; set; }
        public Nullable<System.Guid> TenantID { get; set; }

        public virtual ICollection<ContratDetail> ContratDetails { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
