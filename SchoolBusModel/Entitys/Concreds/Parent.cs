using SchoolBusModel.Entitys.abstrcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusModel.Entitys.normul
{
    public class Parent : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
