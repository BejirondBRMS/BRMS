using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BRMS.Model;

namespace BRMS.BL.Infrastructure
{
   public interface IEmployeeRepository
   {
       IEnumerable<Employee> GetEmployeeByHigherDate(DateTime higherDate);
   }
}
