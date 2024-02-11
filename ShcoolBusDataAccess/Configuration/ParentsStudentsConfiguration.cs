using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolBusModel.Entitys.Concreds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShcoolBusDataAccess.Configuration
{
    internal class ParentsStudentsConfiguration : IEntityTypeConfiguration<ParentsStudents>
    {
        public void Configure(EntityTypeBuilder<ParentsStudents> builder)
        {

            builder.HasData(
                
                new ParentsStudents() { Id = 1, ParentId = 1 , StudentId = 1 },
                new ParentsStudents() { Id = 2, ParentId = 2 , StudentId = 2 }
                                
                );

        }
    }
}
