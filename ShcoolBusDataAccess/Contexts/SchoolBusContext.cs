using Microsoft.EntityFrameworkCore;
using SchoolBusModel.Entitys.normul;
using ShcoolBusDataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShcoolBusDataAccess.Contexts
{
    internal class SchoolBusContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string StrConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolBuss;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";



            optionsBuilder.UseLazyLoadingProxies(true);
            optionsBuilder.UseSqlServer(StrConnection);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        

            //modelBuilder.ApplyConfiguration(new CarConfiguration());
            //modelBuilder.ApplyConfiguration(new ClassConfihuration());
            //modelBuilder.ApplyConfiguration(new DriverConfiguration());
            //modelBuilder.ApplyConfiguration(new ParentConfiguration());
            //modelBuilder.ApplyConfiguration(new StudentConfiguration());



            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Student> Students { get; set; }



    }
}
