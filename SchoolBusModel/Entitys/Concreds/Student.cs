using SchoolBusModel.Entitys.abstrcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusModel.Entitys.normul
{
    public class Student : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Parent> Parents { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
