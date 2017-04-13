using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class BankAccount
    {
        public BankAccount()
        {
            this.LandLords = new HashSet<LandLord>();
        }
       [Key]
        public System.Guid AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string AccountAreaBank { get; set; }

        public virtual ICollection<LandLord> LandLords { get; set; }
    }
}
