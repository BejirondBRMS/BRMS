using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class Address
    {
       [Key]
        public System.Guid AddressID { get; set; }
        public string CellPhone { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string HouseNumber { get; set; }
        public string Woreda { get; set; }
        public string KifleKetema { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Nullable<System.Guid> PersonID { get; set; }
        public Nullable<System.Guid> CompanyID { get; set; }

        public virtual Company Company { get; set; }
        public virtual Person Person { get; set; }
    }
}
