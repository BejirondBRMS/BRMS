using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class Expense
    {
       [Key]
        public System.Guid ExpenseID { get; set; }
        public decimal ExpenseAmount { get; set; }
        public int TypeOfExpense { get; set; }
        public System.DateTime ExpenseDate { get; set; }
        public string ExpenseReason { get; set; }
        public Nullable<System.Guid> propertyID { get; set; }
        public Nullable<System.Guid> OwnedByID { get; set; }
        public bool IsExpenseByCompany { get; set; }
        public Nullable<System.Guid> MaintenanceID { get; set; }

        public virtual Maintenance Maintenance { get; set; }
        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
