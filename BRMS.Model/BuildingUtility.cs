using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class BuildingUtility
    {
        [Key]
        public System.Guid BuildingUtilID { get; set; }
        public System.DateTime ChargeDate { get; set; }
        public System.Guid ChargeType { get; set; }
        public decimal ChargeAmount { get; set; }
        public System.Guid BuildingID { get; set; }

        public virtual Building Building { get; set; }
    }
}
