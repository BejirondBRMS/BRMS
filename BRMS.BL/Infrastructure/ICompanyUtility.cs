using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRMS.Model;

namespace BRMS.BL.Infrastructure
{
    public interface ICompanyUtility
    {
        DataTable GetAllCompany();
        List<Company> GetCompanyById(Guid id);
    }
}
