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
    internal class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.Property(c => c.FirstName).HasColumnType("nvarchar(30)");
            builder.Property(c => c.LastName).HasColumnType("nvarchar(30)");
            builder.Property(c => c.LastName).HasColumnType("nvarchar(13)");

            builder.HasData(
                new Parent() { Id=1, FirstName = "Parent_1", LastName="Parent_1", Phone="050-234-56-87"},
                new Parent() { Id=2, FirstName = "Parent_2", LastName="Parent_2", Phone="055-837-17-54"}
                
                
                );
        }
    }
}
