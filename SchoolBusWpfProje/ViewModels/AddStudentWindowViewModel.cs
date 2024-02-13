using Microsoft.VisualBasic;
using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.View;
using ShcoolBusDataAccess.Repositoriess.Abstructs;
using ShcoolBusDataAccess.Repositoriess.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolBusWpfProje.ViewModels
{
    public class AddStudentWindowViewModel
    {
        public BasePageView BasePageView { get; set; }
        public List<string> CarNames { get; set; }

        BaseRepositories<Car> baseRepositories { get; set; }
        AddStudentWindowView AddStudentWindowView { get; set; }
        public MyRealyCommand CloseCommand { get; set; }
        public MyRealyCommand AddCommand { get; set; }
        int StudentID { get; set; }
        public AddStudentWindowViewModel(BasePageView basePageView, AddStudentWindowView addStudentWindowView, int Id)
        {
            CarNames = new List<string>();
            baseRepositories = new BaseRepositories<Car>();
            AddStudentWindowView = addStudentWindowView;
            CloseCommand = new MyRealyCommand(CloseProgramCommand);
            AddCommand = new MyRealyCommand(AddCommandFunction, CanAddCommandFunction);
            StudentID = Id;

            BasePageView = basePageView;
            var Cars = baseRepositories.GetAllEntity();

            foreach (var car in Cars)
            {
                if(car.Capacity != car.FullPlace && car.Driver is null) { continue; }
                CarNames.Add($"{car.Id},  {car.Marka},  {car.CarNumber}" );
            }


        }


        public void AddCommandFunction(object? parameter)
        {
            var Cars = baseRepositories.GetAllEntity();
            ComboBox comboBox = parameter as ComboBox;
            BaseRepositories<Student> bRStudent = new BaseRepositories<Student>();
            var students = bRStudent.GetAllEntity();

            string str = comboBox.Text.ToString();
           

            foreach (var car in Cars) { 
            
                if($"{car.Id},  {car.Marka},  {car.CarNumber}" == str) {

                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].Id == StudentID)
                        {
                          

                            students[i].CarId = car.Id;
                            students[i].Car.FullPlace += 1;
                            break;
                        }
                    }
                }

            }

            bRStudent.Save();

            BasePageView.BasePageFream.Navigate(new ReaderView() { DataContext = new ReaderViewModel(BasePageView)});
            AddStudentWindowView.Close();

        }


        public bool CanAddCommandFunction(object? parameter)
        {
            ComboBox comboBox = parameter as ComboBox;

            if (comboBox.Text == "") {return false; }
            return true;

        }

        public void CloseProgramCommand(object? par)
        {
            AddStudentWindowView.Close();
        }
    }
}
