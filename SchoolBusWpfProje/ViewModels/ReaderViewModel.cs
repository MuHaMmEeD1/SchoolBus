using SchoolBusModel.Entitys.Concreds;
using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.DTOS;
using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.View;
using ShcoolBusDataAccess.Repositoriess.Abstructs;
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


        public List<string> StudentFullNames { get; set; } = new List<string>();
        public List<string> ParentNames { get; set; } = new List<string>();
        public List<string> ClassNames { get; set; } = new List<string>();
        public List<string> CarNames { get; set; } = new List<string>();


        public MyRealyCommand AddStudentCommand { get; set; }



        BaseRepositories<Student> baseRepositories { get; set; } 

        public ReaderViewModel(BasePageView basePageView)
        {
            baseRepositories = new BaseRepositories<Student>();
            this.basePageView = basePageView;

            RemoveCommand = new MyRealyCommand(RemoveCommandFunction);
            AddCommand = new MyRealyCommand(AddCommandFunction);
            AddStudentCommand = new MyRealyCommand(AddStudentCommandFunction, CanAddStudentCommandFunction);

            DTOS_StudentPReader();
            StudentFullNamesFunction();
            ParentNamesFunction();
            ClassNamesFunction();
            CarNamesFunction();
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

            var Parents = new BaseRepositories<Parent>().GetAllEntity();
            studentPageReader.Clear();
            studentPageReaderQeydiyatsizlar.Clear();

            foreach (Student student in baseRepositories.GetAllEntity())
            {


                string ParentsNames = "";
                foreach (var parent_student in student.ParentsStudents)
                {
                    for (int i = 0; i < Parents.Count; i++)
                    {
                        if (Parents[i].Id == parent_student.ParentId)
                        {
                            ParentsNames += Parents[i].FirstName + " ";
                        }
                    }
                   
                }

                if (ParentsNames != "" && student.ClassId != 0)
                {
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


        public void StudentFullNamesFunction()
        {
            BaseRepositories<Student> baseRepositories = new BaseRepositories<Student>();
            BaseRepositories<Parent> baseRepositoriesParents = new BaseRepositories<Parent>();

            var students = baseRepositories.GetAllEntity();
            var parents = baseRepositoriesParents.GetAllEntity();

            foreach (var student in students)
            {
                string parentsNames = "";
                foreach (var parStu in student.ParentsStudents)
                {
                    foreach (var par in parents)
                    {

                        if(par.Id == parStu.ParentId) { parentsNames += par.FirstName; }

                    }
                }


                if(student.ClassId != 0 && parentsNames.Length != 0) { continue; }
                StudentFullNames.Add($"{student.Id},  {student.FirstName},  {student.LastName}");

            }

        }

        public void ParentNamesFunction()
        {
            BaseRepositories<Parent> baseRepositories = new BaseRepositories<Parent>();
            var parents = baseRepositories.GetAllEntity();

            foreach (var parent in parents)
            {

                ParentNames.Add($"{parent.Id},  {parent.FirstName},  {parent.LastName}");

            }

        }
        public void ClassNamesFunction()
        {
            BaseRepositories<Class> baseRepositories = new BaseRepositories<Class>();
            var Class = baseRepositories.GetAllEntity();

            foreach (var clas in Class)
            {
                if(clas.Id == 0) { continue; }
                ClassNames.Add($"{clas.Id},  {clas.Name}");

            }

        }

        public void CarNamesFunction()
        {
            BaseRepositories<Car> baseRepositories = new BaseRepositories<Car>();
            var Cars = baseRepositories.GetAllEntity();

            foreach (var car in Cars)
            {
                bool yoxla = true;
                foreach (var item in new BaseRepositories<Driver>().GetAllEntity())
                {
                    if (item.CarId == car.Id) { yoxla = false; break; }
                }

                if (car.Id == 0 || car.FullPlace == car.Capacity || yoxla) { continue; }
                CarNames.Add($"{car.Id},  {car.Marka},  {car.CarNumber}");

            }

        }



        public void AddStudentCommandFunction(object? par)
        {

            StackPanel stackPanel = par as StackPanel;
            int ClassId = 0;
            int CarId = 0;

            var Students = baseRepositories.GetAllEntity();
            var Parents = new BaseRepositories<Parent>().GetAllEntity();
            var Class = new BaseRepositories<Class>().GetAllEntity();
            var Cars = new BaseRepositories<Car>().GetAllEntity();



            ComboBox StudentComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox ParentComboBox1 = stackPanel.Children[1] as ComboBox;
            ComboBox ParentComboBox2 = stackPanel.Children[2] as ComboBox;
            ComboBox ClassComboBox = stackPanel.Children[3] as ComboBox;
            ComboBox CarComboBox = stackPanel.Children[4] as ComboBox;

            foreach (var clas in Class)
            {
                if ($"{clas.Id},  {clas.Name}" == ClassComboBox.Text) { ClassId = clas.Id; }
            }
            
            foreach (var car in Cars)
            {
                if ($"{car.Id},  {car.Marka},  {car.CarNumber}" == CarComboBox.Text) { CarId = car.Id; }
            }

           

            for (int i = 0; i < Students.Count; i++)
            {
                if ($"{Students[i].Id},  {Students[i].FirstName},  {Students[i].LastName}" == StudentComboBox.Text)
                {
                    Students[i].ClassId = ClassId;
                    Students[i].CarId = CarId;
                    Students[i].Car.FullPlace += 1;

                    Students[i].ParentsStudents = new List<ParentsStudents>();

                    for (int j = 0; j < Parents.Count; j++)
                    {
                        if ($"{Parents[j].Id},  {Parents[j].FirstName},  {Parents[j].LastName}" == ParentComboBox1.Text || $"{Parents[j].Id},  {Parents[j].FirstName},  {Parents[j].LastName}" == ParentComboBox2.Text)
                        {
                            Students[i].ParentsStudents.Add(new ParentsStudents() { ParentId = Parents[j].Id, StudentId = Students[i].Id ,Student = Students[i], Parent = Parents[j] });
                        }
                    }
                    break;
                }
            }
            baseRepositories.Save();
            ReaderView readerView = new ReaderView();
            readerView.DataContext = new ReaderViewModel(basePageView);
            basePageView.BasePageFream.Navigate(readerView);
        }

        public bool CanAddStudentCommandFunction(object? par)
        {
            StackPanel stackPanel = par as StackPanel;


            ComboBox StudentComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox ParentComboBox1 = stackPanel.Children[1] as ComboBox;
            ComboBox ParentComboBox2 = stackPanel.Children[2] as ComboBox;
            ComboBox ClassComboBox = stackPanel.Children[3] as ComboBox;


            if(
                StudentComboBox.Text != "" &&
                (ParentComboBox1.Text != "" ||
                ParentComboBox2.Text != "" )&&
                ClassComboBox.Text != ""
                )
            { return true; }



            return false;

        }

    }
}

