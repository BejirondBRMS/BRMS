using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRMS.Model;

namespace BRMS.BL.Infrastructure
{
  public  class BrmsContext:DbContext
    {
      public BrmsContext() : base("name=BrmsConection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<BrmsContext>(null);
        }
        public DbSet<vwInspections> VwInspectionses { get; set; }
        public DbSet<vwEmployeePersons> VwEmployeePersons { get; set; }
        public DbSet<vwBuildingUtilities> VwBuildingUtilitieses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingUtility> BuildingUtilities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<ContratDetail> ContratDetails { get; set; }
        public DbSet<ContratSummery> ContratSummeries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<FloorRate> FloorRates { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<LandLord> LandLords { get; set; }
        public DbSet<LookUpType> LookUpTypes { get; set; }
        public DbSet<LookUpValue> LookUpValues { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PlateNumber> PlateNumbers { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RentPayment> RentPayments { get; set; }        
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<UtilityPayment> UtilityPayments { get; set; }
    }
}
