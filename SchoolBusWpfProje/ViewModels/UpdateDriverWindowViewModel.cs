using MaterialDesignThemes.Wpf;
using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.View;
using ShcoolBusDataAccess.Repositoriess.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolBusWpfProje.ViewModels
{
    public class UpdateDriverWindowViewModel
    {
        UpdateDriverWindowView UpdateParentWindowView { get; set; }
        BasePageView basePageView { get; set; }
        int Id { get; set; }

        BaseRepositories<Driver> baseRepositories { get; set; }

        public MyRealyCommand CloseCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }
        public List<string> CarNames { get; set; }

        public UpdateDriverWindowViewModel(UpdateDriverWindowView updateParentWindowView, BasePageView basePageView, int ıd)
        {
            UpdateParentWindowView = updateParentWindowView;
            this.basePageView = basePageView;
            Id = ıd;
            baseRepositories = new BaseRepositories<Driver>();
            CarNames = new List<string>();

            CloseCommand = new MyRealyCommand(CloseProgramCommand);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction, CanUpdateCommandFunction);

            var parent = baseRepositories.GetEntity(Id);

            UpdateParentWindowView.ComboBoxFirstName.Text = parent.FirstName;
            UpdateParentWindowView.ComboBoxLastName.Text = parent.LastName;
            UpdateParentWindowView.ComboBoxPhone.Text = parent.Phone;

            BaseRepositories<Car> baseRepositories2 = new BaseRepositories<Car>();
            var Cars = baseRepositories2.GetAllEntity();

            foreach (var car in Cars)
            {
                bool yoxla = true;
                foreach (var item in baseRepositories.GetAllEntity())
                {
                    
                    if(item.CarId == car.Id && car.Id!=0) { yoxla = false; break; }
                }
                if(yoxla) { CarNames.Add($"{car.Id},  {car.Marka},  {car.CarNumber}"); }
            }
        }




        public void UpdateCommandFunction(object? par)
        {
            string firstName = UpdateParentWindowView.ComboBoxFirstName.Text;
            string lastName = UpdateParentWindowView.ComboBoxLastName.Text;
            string phone = UpdateParentWindowView.ComboBoxPhone.Text;

            var parent = baseRepositories.GetEntity(Id);
            parent.FirstName = firstName;
            parent.LastName = lastName;
            parent.Phone = phone;


            string str = UpdateParentWindowView.ComboBoxCarId.Text.ToString();
            BaseRepositories<Car> rp = new BaseRepositories<Car>();

            foreach (var car in rp.GetAllEntity())
            {

                if ($"{car.Id},  {car.Marka},  {car.CarNumber}" == str)
                {

                    parent.CarId = car.Id; break;
                }

            }


            baseRepositories.Save();

            DriverView driverView = new DriverView();
            driverView.DataContext = new DriverViewModel(basePageView);
            basePageView.BasePageFream.Navigate(driverView);

            UpdateParentWindowView.Close();


        }


        public bool CanUpdateCommandFunction(object? par)
        {
            string firstName = UpdateParentWindowView.ComboBoxFirstName.Text;
            string lastName = UpdateParentWindowView.ComboBoxLastName.Text;
            string phone = UpdateParentWindowView.ComboBoxPhone.Text;
            string carIdStr = UpdateParentWindowView.ComboBoxCarId.Text;

                 

            if (!Regex.IsMatch(phone, @"^\d{3}-\d{3}-\d{2}-\d{2}$")) { return false; }

            if (firstName.Length < 3 || firstName.Length > 29) { return false; }
            if (lastName.Length < 3 || lastName.Length > 29) { return false; }


            return true;
        }



        public void CloseProgramCommand(object? par)
        {
            UpdateParentWindowView.Close();
        }
    }
}
