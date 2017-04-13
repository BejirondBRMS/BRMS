using System.Collections.Generic;
using BRMS.Model;

namespace BRMS.BL.Infrastructure
{
   public interface ILookupValueRepository
   {
       List<LookUpValue> GetLookUpValuesByType(int typeId);
   }
}
