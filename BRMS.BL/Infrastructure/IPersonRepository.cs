using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BRMS.Model;

namespace BRMS.BL.Infrastructure
{
    public interface IPersonRepository
    {
        DataTable GetAllPerson();
        List<Person> GetPersonById(Guid id);

    }
}
