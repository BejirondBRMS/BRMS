using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class Company
    {
        public Company()
        {
            this.Addresses = new HashSet<Address>();
            this.Contractors = new HashSet<Contractor>();
            this.LandLords = new HashSet<LandLord>();
            this.Tenants = new HashSet<Tenant>();
        }
        [Key]
        public System.Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public Guid CompanyType { get; set; }
        public string TradeRegistrationNo { get; set; }
        public string TaxRegistrationNo { get; set; }
        public Guid TaxType { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Contractor> Contractors { get; set; }
        public virtual ICollection<LandLord> LandLords { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
