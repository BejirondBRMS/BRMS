using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class Person
    {
        public Person()
        {
            this.Addresses = new HashSet<Address>();
            this.LandLords = new HashSet<LandLord>();
            this.Tenants = new HashSet<Tenant>();
        }
        [Key]
        public System.Guid PersonID { get; set; }
        public Guid Title { get; set; }
        public string PersonIDGov { get; set; }
        public string GovIDType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public System.DateTime BirthDate { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<LandLord> LandLords { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
