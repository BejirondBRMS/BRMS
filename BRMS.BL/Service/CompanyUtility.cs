using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRMS.BL.Infrastructure;

namespace BRMS.BL.Service
{
    public class CompanyUtility : ICompanyUtility
    {
        private readonly BrmsContext _db;

        public CompanyUtility(BrmsContext db)
        {
            _db = db;
        }

        public System.Data.DataTable GetAllCompany()
        {
            var list = from c in _db.Companies
                       join lv in _db.LookUpValues on c.CompanyType equals lv.ID
                       select new { CompanyType = lv.Value, CompanyName = c.CompanyName, TradeRegistrationNo = c.TradeRegistrationNo, TaxRegistrationNo = c.TaxRegistrationNo, CompanyId = c.CompanyID };

            var converter = new ListtoDataTableConverter();
            var dt = converter.ToDataTable(list.ToList());
            return dt;
        }

        public List<Model.Company> GetCompanyById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
