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
using System.Windows.Controls;

namespace SchoolBusWpfProje.ViewModels
{
    public class StudentViewModel
    {
        public BasePageView basePageView { get; set; }
        BaseRepositories<Student> baseRepositories { get; set; }
        public List<StudentPageListView> studentPageListViews { get; set; }

        public MyRealyCommand AddCommand { get; set; }
        public MyRealyCommand RemoveCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }

        public StudentViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
            baseRepositories = new BaseRepositories<Student>();
            studentPageListViews = new List<StudentPageListView>();

            AddCommand = new MyRealyCommand(AddCommandFunction, CanAddCommandFunction);
            RemoveCommand = new MyRealyCommand(RemoveCommandFunction);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction);
            StudentPageDTOS();
        }


        void StudentPageDTOS()
        {
            var students = baseRepositories.GetAllEntity();

            foreach (var item in students)
            {
                studentPageListViews.Add(

              new StudentPageListView() { Id = item.Id,
                                          FirstName = item.FirstName,
                                          LastName = item.LastName
              });
            }
          

        }

        public void AddCommandFunction(object? par)
        {
            StackPanel stackPanel = par as StackPanel;
           
            var Students = baseRepositories.GetAllEntity();
           


            ComboBox FirstNameComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox LastNameComboBox = stackPanel.Children[1] as ComboBox;


            baseRepositories.Add(new Student() { FirstName = FirstNameComboBox.Text , LastName = LastNameComboBox.Text });
            baseRepositories.Save();

            StudentView studentView = new StudentView();
            studentView.DataContext = new StudentViewModel(basePageView);
            basePageView.BasePageFream.Navigate(studentView);

        }


        public bool CanAddCommandFunction(object? par)
        {
            StackPanel stackPanel = par as StackPanel;

            var Students = baseRepositories.GetAllEntity();

            ComboBox FirstNameComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox LastNameComboBox = stackPanel.Children[1] as ComboBox;

            string firstName = FirstNameComboBox?.Text;
            string lastName = LastNameComboBox?.Text;


            if (firstName.Length < 3 || firstName.Length > 29) { return false; }
            if (lastName.Length < 3 || lastName.Length > 29) { return false; }

            return true;
        }


        public void RemoveCommandFunction(object? par)
        {
            Label label = par as Label;
            int Id = int.Parse(label.Content.ToString());

            var entity = baseRepositories.GetEntity(Id);
            baseRepositories.Delete(entity);
            baseRepositories.Save();

            StudentView studentView = new StudentView();
            studentView.DataContext = new StudentViewModel(basePageView);
            basePageView.BasePageFream.Navigate(studentView);

        }

        public void UpdateCommandFunction(object? par)
        {
            Label label = par as Label;
            int id = int.Parse(label.Content.ToString());


            UpdateStudentWindowView updateStudentWindowView = new UpdateStudentWindowView();
            updateStudentWindowView.DataContext = new UpdateStudentWindowViewModel(updateStudentWindowView, basePageView, id);
            updateStudentWindowView.Show();

        }








    }
}
