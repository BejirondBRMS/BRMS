using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class FloorRate
    {
       [Key]
        public System.Guid FloorRateID { get; set; }
        public string FloorNo { get; set; }
        public decimal RentAmount { get; set; }
        public System.Guid BuildingID { get; set; }

        public virtual Building Building { get; set; }
    }
}
