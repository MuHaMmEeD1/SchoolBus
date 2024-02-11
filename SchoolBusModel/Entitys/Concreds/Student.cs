using SchoolBusModel.Entitys.abstrcut;
using SchoolBusModel.Entitys.Concreds;
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

        public virtual ICollection<ParentsStudents> ParentsStudents { get; set; } = null;
        public int? ClassId { get; set; } = null;
        public virtual Class Class { get; set; }

        public int? CarId { get; set; } = null;
        public virtual Car Car { get; set; }
    }
}
