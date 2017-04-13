using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class LookUpValue
    {
       [Key]
        public System.Guid ID { get; set; }
        public Nullable<int> Type { get; set; }
        public string Value { get; set; }
        public Nullable<System.Guid> SelfParentID { get; set; }
    }
}
