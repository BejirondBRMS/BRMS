using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using BRMS.BL.Infrastructure;
using BRMS.BL.Service;
using BRMS.Model;


namespace BRMS.BL.Repository
{

    public class PersonRepository : IPersonRepository
    {
        private readonly BrmsContext _db;

        public PersonRepository(BrmsContext db)
        {
            _db = db;
        }


        public DataTable GetAllPerson()
        {
            //var list = (from p in _db.People join lv in _db.LookUpValues on p.Title equals lv.ID select p).ToList();
            var list = from p in _db.People join lv in _db.LookUpValues on p.Title equals lv.ID select new 
            { Title = lv.Value, Name = p.FirstName , MName=p.MiddleName, LName=p.LastName, Sex=p.Sex, IdNo= p.PersonIDGov, PersonID=p.PersonID};

            var converter = new ListtoDataTableConverter();
            var dt = converter.ToDataTable(list.ToList());
            return dt;
        }

        public List<Person> GetPersonById(Guid id)
        {
            var list = (from p in _db.People where p.PersonID == id select p).ToList();
            return list;

        }
    }

}