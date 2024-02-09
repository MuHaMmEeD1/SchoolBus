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
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.Property(c => c.FirstName).HasColumnType("nvarchar(30)");
            builder.Property(c => c.LastName).HasColumnType("nvarchar(30)");


        }
    }
}


            