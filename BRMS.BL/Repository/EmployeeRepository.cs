using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRMS.BL.Infrastructure;
using BRMS.Model;

namespace BRMS.BL.Repository
{
  
        public class EmployeeRepository : IEmployeeRepository, IDisposable
        {
            private BrmsContext _context;

            public EmployeeRepository(BrmsContext context)
            {
                this._context = context;
            }
            public List<Employee> GetEmployees()
            {
                return _context.Employees.ToList();
            }

            public IEnumerable<Employee> GetEmployeeByHigherDate(DateTime higherDate)
            {
                return _context.Employees.Where(e=>e.HireDate==higherDate);
            }

            
            public void Save()
            {
                _context.SaveChanges();
            }

            private bool _disposed = false;
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }
                }
                _disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    
}
