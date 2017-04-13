using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class Maintenance
    {
        public Maintenance()
        {
            this.Expenses = new HashSet<Expense>();
        }
        [Key]
        public System.Guid MaintenanceID { get; set; }
        public System.DateTime DamageDate { get; set; }
        public string DamagedItem { get; set; }
        public bool IsMaintained { get; set; }
        public Nullable<System.DateTime> MaintenanceDate { get; set; }
        public string MaintenanceDescription { get; set; }
        public System.Guid PropertyID { get; set; }
        public Nullable<System.Guid> InspectionID { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual Inspection Inspection { get; set; }
        public virtual Property Property { get; set; }
    }
}
