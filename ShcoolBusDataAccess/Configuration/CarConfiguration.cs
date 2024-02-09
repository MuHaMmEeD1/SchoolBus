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
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c=>c.Id).ValueGeneratedNever();
            builder.Property(c => c.CarNumber).HasColumnType("nvarchar(9)");
            builder.Property(c => c.Marka).HasColumnType("nvarchar(20)");
            builder.Property(c => c.Model).HasColumnType("nvarchar(20)");
            builder.Property(c => c.Capacity).HasAnnotation("CK_Car_Capacity", "Capacity >= 10 and Capacity <= 40");


            builder.HasData(
                new Car() { Id=0, Marka = "default", Model="default", CarNumber="00-aa-000", Capacity = 10, FullPlace = 0},
                new Car() { Id=1, Marka = "BWE", Model="BWE12", CarNumber="01-MN-001", Capacity = 20, FullPlace = 0 },
                new Car() { Id=2, Marka = "KIA", Model="KIA12", CarNumber="02-WY-245", Capacity = 22, FullPlace = 0 }
                
                );
        }
    }
}