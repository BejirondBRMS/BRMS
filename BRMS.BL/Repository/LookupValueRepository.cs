using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRMS.BL.Infrastructure;
using BRMS.Model;

namespace BRMS.BL.Repository
{
    public class LookupValueRepository : ILookupValueRepository, IDisposable
    {
        private BrmsContext _context;

        public LookupValueRepository(BrmsContext context)
        {
            this._context = context;
        }
        public List<LookUpValue> GetLookUpValuesByType(int typeId)
        {
            return _context.LookUpValues.Where(v=>v.Type==typeId).ToList();
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
