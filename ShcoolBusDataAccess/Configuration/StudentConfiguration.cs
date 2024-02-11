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

            builder.HasData(
                new Student() { Id = 1, FirstName = "Student_1", LastName = "Student_1", CarId = 1, ClassId = 1 },
                new Student() { Id = 2, FirstName = "Student_2", LastName = "Student_2", CarId = 2, ClassId = 2 },
                new Student() { Id = 3, FirstName = "Student_3", LastName = "Student_3", CarId = 0, ClassId = 0 });

        }
    }
}


            