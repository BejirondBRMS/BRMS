using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class LandLord
    {
       [Key]
        public System.Guid OwnerID { get; set; }
        public Nullable<System.Guid> PersonID { get; set; }
        public Nullable<System.Guid> CompanyID { get; set; }
        public Nullable<System.Guid> AccountID { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual Company Company { get; set; }
        public virtual Person Person { get; set; }
    }
}
