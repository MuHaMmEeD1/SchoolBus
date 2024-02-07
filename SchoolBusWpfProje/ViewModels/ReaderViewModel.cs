using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.DTOS;
using SchoolBusWpfProje.View;
using ShcoolBusDataAccess.Repositoriess.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.ViewModels
{
    public class ReaderViewModel
    {
        public BasePageView basePageView { get; set; }
        public List<StudentPageReader> studentPageReader { get; set; }

        public ReaderViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;


        }


        public void DTOS_StudentPReader()
        {

            BaseRepositories<Student> StudentBR = new BaseRepositories<Student>();

            foreach (Student student in StudentBR.GetAllEntity()) { 
            
                studentPageReader
            
            }

        }


    }
}
