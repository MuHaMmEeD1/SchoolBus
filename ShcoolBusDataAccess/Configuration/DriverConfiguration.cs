using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolBusModel.Entitys.normul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShcoolBusDataAccess.Configuration
{
    internal class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.Property(c => c.FirstName).HasColumnType("nvarchar(30)");
            builder.Property(c => c.LastName).HasColumnType("nvarchar(30)");
            builder.Property(c => c.LastName).HasColumnType("nvarchar(13)");
            builder.Property(c => c.CarId).IsRequired(false);

            builder.HasData(
                new Driver() { Id = 1, FirstName="Driver_1", LastName="Driver_1", Phone="055-234-45-87", CarId=1},
                new Driver() { Id = 2, FirstName="Driver_2", LastName="Driver_2", Phone="070-345-26-76", CarId=2}
                
                
                );
        }
    }
}
