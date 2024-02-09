using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.DTOS;
using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.View;
using ShcoolBusDataAccess.Repositoriess.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SchoolBusWpfProje.ViewModels
{
    public class ReaderViewModel
    {
        public BasePageView basePageView { get; set; }
        public List<StudentPageReader> studentPageReader { get; set; } = new List<StudentPageReader>();
        public List<StudentPageReader> studentPageReaderQeydiyatsizlar { get; set; } = new List<StudentPageReader>();
        public StudentPageReader StudentPage {  get; set; }
        public MyRealyCommand AddCommand { get; set; } 
        public MyRealyCommand RemoveCommand { get; set; }


        BaseRepositories<Student> baseRepositories { get; set; } 

        public ReaderViewModel(BasePageView basePageView)
        {
            baseRepositories = new BaseRepositories<Student>();
            this.basePageView = basePageView;

            RemoveCommand = new MyRealyCommand(RemoveCommandFunction);
            AddCommand = new MyRealyCommand(AddCommandFunction);

            DTOS_StudentPReader();
        }

        
        void RemoveCommandFunction(object? par) 
        {
            Label label = par as Label;
            int id = (int)label.Content;

            var Students = baseRepositories.GetAllEntity();
            for (int i = 0; i < Students.Count; i++)
            {
                if (id == Students[i].Id)
                {
                    Students[i].Car.FullPlace -= 1;
                    Students[i].CarId = 0;
                }
            }
                
            


            baseRepositories.Save();
            DTOS_StudentPReader();

            basePageView.BasePageFream.Navigate(new ReaderView() { DataContext = new ReaderViewModel(basePageView)});
        }
        void AddCommandFunction(object? par)
        {
            Label label = par as Label; 
            int id = (int) label.Content;

            AddStudentWindowView addStudentWindowView = new AddStudentWindowView();
            addStudentWindowView.DataContext = new AddStudentWindowViewModel(basePageView, addStudentWindowView, id);
            addStudentWindowView.Show();

        }


        public void DTOS_StudentPReader()
        {


            studentPageReader.Clear();
            studentPageReaderQeydiyatsizlar.Clear();

            foreach (Student student in baseRepositories.GetAllEntity()) {


                string ParentsNames = "";
                foreach (var parent in student.Parents)
                {
                    ParentsNames += parent.FirstName + " ";
                }
                if (student.CarId > 0)
                {
                    studentPageReader.Add(
                        new StudentPageReader()
                        {
                            Id = student.Id,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            ClassName = student.Class.Name,
                            ParentsNames = ParentsNames,

                        });
                }
                else
                {

                    studentPageReaderQeydiyatsizlar.Add(
                        new StudentPageReader()
                        {
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
}
