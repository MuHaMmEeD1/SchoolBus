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
    public class UpdateClassWindowViewModel
    {

        UpdateClassWindowView updateStudentWindowView { get; set; }
        public BasePageView BasePageView { get; set; }
        int Id { get; set; }

        public MyRealyCommand CloseCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }
        BaseRepositories<Class> baseRepositories { get; set; } 

        public UpdateClassWindowViewModel(UpdateClassWindowView updateStudentWindow, BasePageView basePageView, int Id)
        {
            updateStudentWindowView = updateStudentWindow;
            BasePageView = basePageView;
            this.Id = Id;
            baseRepositories = new BaseRepositories<Class>();
            var clas = baseRepositories.GetEntity(Id);


            updateStudentWindow.ComboBoxClassName.Text = clas.Name;
            CloseCommand = new MyRealyCommand(CloseProgramCommand);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction, CanUpdateCommandFunction);
        }







        public bool CanUpdateCommandFunction(object? par)
        {
            string str = updateStudentWindowView.ComboBoxClassName.Text;
            if (str.Length > 19 || str.Length < 3) { return false; }

            return true;
        }


        public void UpdateCommandFunction(object? par)
        {
            var clas = baseRepositories.GetEntity(Id);
            clas.Name = updateStudentWindowView.ComboBoxClassName.Text;

            baseRepositories.Save();

            ClassView classView = new ClassView();
            classView.DataContext = new ClassViewModel(BasePageView);
            BasePageView.BasePageFream.Navigate(classView);
            updateStudentWindowView.Close();

        }


        public void CloseProgramCommand(object? par)
        {
            updateStudentWindowView.Close();
        }



    }
}
