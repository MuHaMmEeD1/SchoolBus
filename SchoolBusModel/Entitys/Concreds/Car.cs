using SchoolBusModel.Entitys.abstrcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusModel.Entitys.normul
{
    public class Car : BaseEntity
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string CarNumber { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
