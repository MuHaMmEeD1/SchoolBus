using SchoolBusModel.Entitys.abstrcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusModel.Entitys.normul
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
