using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
  public  class RentPayment
    {
       [Key]
        public System.Guid RentPaymentID { get; set; }
        public string RentPaymentMethod { get; set; }
        public decimal RentPaymentAmount { get; set; }
        public System.DateTime RentPaymentDate { get; set; }
        public string PaymentToAccountNumber { get; set; }
        public string BankName { get; set; }
        public string RentPaymentDescription { get; set; }
        public byte[] ScannedDoc { get; set; }
        public System.DateTime RentDateFrom { get; set; }
        public System.DateTime RentDateTo { get; set; }
        public Nullable<decimal> Penalty { get; set; }
        public System.Guid ContratDetailID { get; set; }
        public System.Guid PropertyID { get; set; }

        public virtual ContratDetail ContratDetail { get; set; }
        public virtual Property Property { get; set; }
    }
}
