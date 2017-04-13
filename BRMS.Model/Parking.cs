using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class Parking
    {
        public Parking()
        {
            this.PlateNumbers = new HashSet<PlateNumber>();
        }
       [Key]
        public int ParkingLot { get; set; }
        public System.Guid TenantID { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<PlateNumber> PlateNumbers { get; set; }
    }
}
