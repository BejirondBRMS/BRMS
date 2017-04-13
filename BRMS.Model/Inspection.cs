using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BRMS.Model
{
    public class Inspection
    {
        public Inspection()
        {
            this.Maintenances = new HashSet<Maintenance>();
        }
        [Key]
        public Guid InspectionID { get; set; }
        public DateTime InspectionDate { get; set; }
        public Nullable<Guid> PropertyID { get; set; }
        public string DamagedItem { get; set; }
        public Nullable<Guid> InspectedBy { get; set; }

        //public virtual Employee Employee { get; set; }
        public virtual Property Property { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
