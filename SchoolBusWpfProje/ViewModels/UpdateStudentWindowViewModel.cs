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

namespace SchoolBusWpfProje.ViewModels
{
    public class UpdateStudentWindowViewModel
    {

        UpdateStudentWindowView updateStudentWindowView{  get; set; }
        BasePageView BasePageView { get; set; }
        int StudentId { get; set; }

        public MyRealyCommand CloseCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }

        BaseRepositories<Student> baseRepositories { get; set; }

        public UpdateStudentWindowViewModel(UpdateStudentWindowView updateStudentWindow, BasePageView basePageView, int studentId)
        {
            updateStudentWindowView = updateStudentWindow;
            BasePageView = basePageView;
            StudentId = studentId;
            baseRepositories = new BaseRepositories<Student>();

            var student = baseRepositories.GetEntity(studentId);

            updateStudentWindow.ComboBoxFirstName.Text = student.FirstName;
            updateStudentWindow.ComboBoxLastName.Text = student.LastName;

            CloseCommand = new MyRealyCommand(CloseProgramCommand);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction, CanUpdateCommandFunction);
        }


        

        



        public void UpdateCommandFunction(object? par)
        {

            var student = baseRepositories.GetEntity(StudentId);
            student.FirstName = updateStudentWindowView.ComboBoxFirstName.Text;
            student.LastName = updateStudentWindowView.ComboBoxLastName.Text;
            baseRepositories.Save();

            StudentView studentView = new StudentView();
            studentView.DataContext = new StudentViewModel(BasePageView);
            BasePageView.BasePageFream.Navigate(studentView);

            updateStudentWindowView.Close();

        }


        public bool CanUpdateCommandFunction(object? par)
        {
            string firstname = updateStudentWindowView.ComboBoxFirstName.Text;
            string lastname = updateStudentWindowView.ComboBoxLastName.Text;

            if(firstname.Length < 3 || firstname.Length > 29) { return false; }
            if(lastname.Length < 3 || lastname.Length > 29) { return false; }

            return true;
        }




        public void CloseProgramCommand(object? par)
        {
            updateStudentWindowView.Close();
        }

    }
}
