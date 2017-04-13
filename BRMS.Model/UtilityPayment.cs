using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class UtilityPayment
    {
        [Key]
        public System.Guid UtilPaymentID { get; set; }
        public string UtilPaymentMethod { get; set; }
        public decimal UtilPaymentAmount { get; set; }
        public System.DateTime UtilPaymentDate { get; set; }
        public string UtilPaymentDepositAccount { get; set; }
        public string BankName { get; set; }
        public string Utility { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> UtilityUsageFrom { get; set; }
        public Nullable<System.DateTime> UtilityUsageTo { get; set; }
        public Nullable<decimal> Penalty { get; set; }
        public Nullable<System.Guid> PropertyID { get; set; }

        public virtual Property Property { get; set; }
    }
}
