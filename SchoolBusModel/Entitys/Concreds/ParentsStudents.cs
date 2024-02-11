using SchoolBusModel.Entitys.abstrcut;
using SchoolBusModel.Entitys.normul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusModel.Entitys.Concreds
{
    public class ParentsStudents : BaseEntity
    {

        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }

        public int StudentId {  get; set; }
        public virtual Student Student { get; set; }

    }
}
