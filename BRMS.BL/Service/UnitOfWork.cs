using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRMS.BL.Infrastructure;
using BRMS.BL.Repository;
using BRMS.Model;

namespace BRMS.BL.Service
{
    public class UnitOfWork : IDisposable
    {
        private BrmsContext _context = new BrmsContext();
        private GenericRepository<Model.Person> _personRepository;
        private GenericRepository<Model.Company> _companyRepository;
        private GenericRepository<LookUpType> _lookUpTypeRepository;
        public GenericRepository<Model.Company> CompanyRepository
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new GenericRepository<Model.Company>(_context);
                }
                return _companyRepository;
            }
        }
        public GenericRepository<Model.Person> PersonRepository
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = new GenericRepository<Model.Person>(_context);
                }
                return _personRepository;
            }
        }

        public GenericRepository<LookUpType> LookUpTypeRepository
        {
            get
            {
                if (_lookUpTypeRepository == null)
                {
                    _lookUpTypeRepository = new GenericRepository<LookUpType>(_context);
                }
                return _lookUpTypeRepository;
            }
        }
        private GenericRepository<LookUpValue> _lookUpValueRepository;

        public GenericRepository<LookUpValue> LookUpValueRepository
        {
            get
            {
                if (_lookUpValueRepository == null)
                {
                    _lookUpValueRepository = new GenericRepository<LookUpValue>(_context);
                }
                return _lookUpValueRepository;
            }
        }

        private GenericRepository<BankAccount> _bankAccountRepository;

        public GenericRepository<BankAccount> BankAccountRepository
        {
            get
            {
                if (_bankAccountRepository == null)
                {
                    _bankAccountRepository = new GenericRepository<BankAccount>(_context);
                }
                return _bankAccountRepository;
            }
        }

        private GenericRepository<Property> _propertyRepository;

        public GenericRepository<Property> PropertyRepository
        {
            get
            {
                if (_propertyRepository == null)
                {
                    _propertyRepository = new GenericRepository<Property>(_context);
                }
                return _propertyRepository;
            }
        }

        private GenericRepository<Building> _buildingRepository;

        public GenericRepository<Building> BuildingRepository
        {
            get
            {
                if (_buildingRepository == null)
                {
                    _buildingRepository = new GenericRepository<Building>(_context);
                }
                return _buildingRepository;
            }
        }

        private GenericRepository<FloorRate> _floorRateRepository;

        public GenericRepository<FloorRate> FloorRateRepository
        {
            get
            {
                if (_floorRateRepository == null)
                {
                    _floorRateRepository = new GenericRepository<FloorRate>(_context);
                }
                return _floorRateRepository;
            }
        }

        private GenericRepository<BuildingUtility> _buildingUtilityRepository;

        public GenericRepository<BuildingUtility> BuildingUtilityRepository
        {
            get
            {
                if (_buildingUtilityRepository == null)
                {
                    _buildingUtilityRepository = new GenericRepository<BuildingUtility>(_context);
                }
                return _buildingUtilityRepository;
            }
        }
        private GenericRepository<Contractor> _contractorRepository;

        public GenericRepository<Contractor> ContractorRepository
        {
            get
            {
                if (_contractorRepository == null)
                {
                    _contractorRepository = new GenericRepository<Contractor>(_context);
                }
                return _contractorRepository;
            }
        }
        private GenericRepository<vwBuildingUtilities> _vwBuildingUtilitiesRepository;

        public GenericRepository<vwBuildingUtilities> VwBuildingUtilitiesRepository
        {
            get
            {
                if (_vwBuildingUtilitiesRepository == null)
                {
                    _vwBuildingUtilitiesRepository = new GenericRepository<vwBuildingUtilities>(_context);
                }
                return _vwBuildingUtilitiesRepository;
            }
        }
        private GenericRepository<Inspection> _inspectionRepository;
        public GenericRepository<Inspection> InspectionRepository
        {
            get
            {
                if (_inspectionRepository == null)
                {
                    _inspectionRepository = new GenericRepository<Inspection>(_context);
                }
                return _inspectionRepository;
            }
        }
        private GenericRepository<vwInspections> _vwInspectionsRepository;
        public GenericRepository<vwInspections> vwInspectionsRepository
        {
            get
            {
                if (_vwInspectionsRepository == null)
                {
                    _vwInspectionsRepository = new GenericRepository<vwInspections>(_context);
                }
                return _vwInspectionsRepository;
            }
        }
        private GenericRepository<Employee> _employeeRepository;
        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new GenericRepository<Employee>(_context);
                }
                return _employeeRepository;
            }
        }
        private GenericRepository<vwEmployeePersons> _vwEmployeePersonRepository;
        public GenericRepository<vwEmployeePersons> vwEmployeePersonRepository
        {
            get
            {
                if (_vwEmployeePersonRepository == null)
                {
                    _vwEmployeePersonRepository = new GenericRepository<vwEmployeePersons>(_context);
                }
                return _vwEmployeePersonRepository;
            }
        }
        private GenericRepository<Maintenance> _maintenanceRepository;
        public GenericRepository<Maintenance> MaintenanceRepository
        {
            get
            {
                if (_maintenanceRepository == null)
                {
                    _maintenanceRepository = new GenericRepository<Maintenance>(_context);
                }
                return _maintenanceRepository;
            }
        }
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                foreach (var validationErrors in dbEx.Entries)
                {
                    foreach (var validationError in validationErrors.ToString())
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.ToString(), validationError.ToString());
                    }
                }
            }

        }
        private bool _disposed;
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
