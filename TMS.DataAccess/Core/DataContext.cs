using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Entities;

namespace TMS.DataAccess.Core
{
    public class DataContext: IdentityDbContext<ApplicationUser>
    {
        public DataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=AMM-016\\SQLEXPRESS01;Database=TMS;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public virtual void Save()
        {
            base.SaveChanges();
        }

        #region Entities representing Database Objects
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobTask> JobTask { get; set; }
        public DbSet<JobWorker> JobWorker { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        #endregion
    }
}
