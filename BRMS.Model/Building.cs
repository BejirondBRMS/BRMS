using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
    public class Building
    {
        public Building()
        {
            this.BuildingUtilities = new HashSet<BuildingUtility>();
            this.FloorRates = new HashSet<FloorRate>();
            this.Properties = new HashSet<Property>();
        }
        [Key]
        public System.Guid BuildingID { get; set; }
        public string BuildingName { get; set; }
        public string Storey { get; set; }
        public string BlockNumber { get; set; }
        public string KifleKetema { get; set; }
        public string Woreda { get; set; }
        public string Kebele { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<BuildingUtility> BuildingUtilities { get; set; }
        public virtual ICollection<FloorRate> FloorRates { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
