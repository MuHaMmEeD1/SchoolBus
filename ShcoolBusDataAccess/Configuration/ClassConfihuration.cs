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
    public class ClassConfihuration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(20)");

            builder.HasData(
                new Class() { Id=0, Name = "Default" },
                new Class() { Id=1, Name = "Class_1" },
                new Class() { Id=2, Name = "Class_2" }

                );
        }
    }
}
