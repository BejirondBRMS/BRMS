using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class ContratDetail
    {
        public ContratDetail()
        {
            this.RentPayments = new HashSet<RentPayment>();
        }
        [Key]
        public System.Guid ContratDetailID { get; set; }
        public System.DateTime ContratDate { get; set; }
        public System.DateTime RentStartDate { get; set; }
        public System.DateTime MoveInDate { get; set; }
        public System.DateTime ContratEndDate { get; set; }
        public Nullable<System.DateTime> ContratRenewDate { get; set; }
        public Nullable<System.DateTime> MoveOutDate { get; set; }
        public Nullable<decimal> AdvancePayment { get; set; }
        public Nullable<decimal> Deposit { get; set; }
        public Nullable<decimal> DepositReturn { get; set; }
        public Nullable<System.DateTime> DepositReturnDate { get; set; }
        public string PayPeriod { get; set; }
        public string ContratDetail1 { get; set; }
        public System.Guid ContratID { get; set; }

        public virtual ContratSummery ContratSummery { get; set; }
        public virtual ICollection<RentPayment> RentPayments { get; set; }
    }
}
