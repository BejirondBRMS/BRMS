using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
  public  class Property
    {

        public Property()
        {
            this.Expenses = new HashSet<Expense>();
            this.Inspections = new HashSet<Inspection>();
            this.Maintenances = new HashSet<Maintenance>();
            this.RentPayments = new HashSet<RentPayment>();
            this.UtilityPayments = new HashSet<UtilityPayment>();
        }
       [Key]
        public System.Guid PropertyID { get; set; }
        public string FloorNo { get; set; }
        public string RoomNo { get; set; }
        public string Area { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid RoomUse { get; set; }
        public Guid Availiability { get; set; }
        public Guid RoomType { get; set; }
        public string RoomDescription { get; set; }
        public System.Guid BuildingID { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
        public virtual ICollection<RentPayment> RentPayments { get; set; }
        public virtual ICollection<UtilityPayment> UtilityPayments { get; set; }
    }
}
