using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class vwBuildingUtilities
    {
        [Key]
        public System.Guid BuildingUtilID { get; set; }
        public System.DateTime ChargeDate { get; set; }        
        public decimal ChargeAmount { get; set; }
        public string ChargeType { get; set; }
        public string BuildingName { get; set; }
    }
}
