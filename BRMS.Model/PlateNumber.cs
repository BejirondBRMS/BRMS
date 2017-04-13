using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMS.Model
{
   public class PlateNumber
    {
      
        public int ParkingLot { get; set; }
        [Key]
        public string PlateNo { get; set; }

        public virtual Parking Parking { get; set; }
    }
}
