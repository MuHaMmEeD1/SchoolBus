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
        public List<StudentPageReader> studentPageReader { get; set; } = new List<StudentPageReader>();
        public StudentPageReader StudentPage {  get; set; }

        public ReaderViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;

            DTOS_StudentPReader();
        }


        public void DTOS_StudentPReader()
        {

            BaseRepositories<Student> StudentBR = new BaseRepositories<Student>();

            studentPageReader.Clear();

            foreach (Student student in StudentBR.GetAllEntity()) {


                string ParentsNames = "";
                foreach (var parent in student.Parents)
                {
                    ParentsNames += parent.FirstName + " ";
                }

                studentPageReader.Add(
                    new StudentPageReader() { 
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        ClassName = student.Class.Name,
                        ParentsNames = ParentsNames,
                        
                });
            
            }

        }


    }
}
