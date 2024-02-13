using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.DTOS;
using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.ViewModels;
using ShcoolBusDataAccess.Repositoriess.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolBusWpfProje.View
{
    public class DriverViewModel
    {
        public BasePageView basePageView { get; set; }
        BaseRepositories<Driver> baseRepositories { get; set; }

        public List<DriverPageListView> driverPageListViews { get; set; }
        public MyRealyCommand AddCommand { get; set; }
        public MyRealyCommand RemoveCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }




        public DriverViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
            baseRepositories = new BaseRepositories<Driver>();
            driverPageListViews = new List<DriverPageListView>();

            AddCommand = new MyRealyCommand(AddCommandFunction, CanAddCommandFunction);
            RemoveCommand = new MyRealyCommand(RemoveCommandFunction);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction);

            DriverDTOS();
        }

        void DriverDTOS()
        {
            var drivers = baseRepositories.GetAllEntity();

            foreach (var dri in drivers)
            {
                driverPageListViews.Add(
                    
                    new DriverPageListView() { 
                        Id = dri.Id,
                        FirstName = dri.FirstName,
                        LastName = dri.LastName,
                        Phone = dri.Phone
                        
                    }
                    
                    );
            }

        }


        public void AddCommandFunction(object? par)
        {
            StackPanel stackPanel = par as StackPanel;

            var drivers = baseRepositories.GetAllEntity();


            ComboBox FirstNameComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox LastNameComboBox1 = stackPanel.Children[1] as ComboBox;
            ComboBox PhoneComboBox2 = stackPanel.Children[2] as ComboBox;

            baseRepositories.Add(
                new Driver()
                {
                    FirstName = FirstNameComboBox.Text,
                    LastName = LastNameComboBox1.Text,
                    Phone = PhoneComboBox2.Text
                }
                );
            baseRepositories.Save();


            DriverView driverView = new DriverView();
            driverView.DataContext = new DriverViewModel(basePageView);
            basePageView.BasePageFream.Navigate(driverView);

        }


        public bool CanAddCommandFunction(object? par)
        {

            StackPanel stackPanel = par as StackPanel;

            ComboBox FirstNameComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox LastNameComboBox1 = stackPanel.Children[1] as ComboBox;
            ComboBox PhoneComboBox2 = stackPanel.Children[2] as ComboBox;

            if (!Regex.IsMatch(PhoneComboBox2.Text, @"^\d{3}-\d{3}-\d{2}-\d{2}$")) { return false; }

            string firStr = LastNameComboBox1.Text;
            string lasStr = FirstNameComboBox.Text;

            if (firStr.Length < 3 || firStr.Length > 29) { return false; }
            if (lasStr.Length < 3 || lasStr.Length > 29) { return false; }


            return true;
        }


        public void RemoveCommandFunction(object? par)
        {
            Label label = par as Label;
            int Id = int.Parse(label.Content.ToString());

            var entity = baseRepositories.GetEntity(Id);
            foreach (var st in entity.Car.Students)
            {
                st.CarId = null;
            }
            entity.CarId = null;

            baseRepositories.Delete(entity);

            baseRepositories.Save();

            DriverView driverView = new DriverView();
            driverView.DataContext = new DriverViewModel(basePageView);
            basePageView.BasePageFream.Navigate(driverView);

        }


        public void UpdateCommandFunction(object? par)
        {
            Label label = par as Label;
            int Id =int.Parse(label.Content.ToString());

            UpdateDriverWindowView updateDriverWindowView = new UpdateDriverWindowView();
            updateDriverWindowView.DataContext = new UpdateDriverWindowViewModel(updateDriverWindowView, basePageView, Id);

            updateDriverWindowView.Show();  


        }



    }
}
