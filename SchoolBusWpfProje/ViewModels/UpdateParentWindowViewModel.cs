using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.View;
using ShcoolBusDataAccess.Repositoriess.Concrets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.ViewModels
{
    public class UpdateParentWindowViewModel
    {

        UpdateParentWindowView UpdateParentWindowView { get; set; }
        BasePageView BasePageView { get; set; }
        int Id { get; set; }

        BaseRepositories<Parent> baseRepositories { get; set; }

        public MyRealyCommand CloseCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }

        public UpdateParentWindowViewModel(UpdateParentWindowView updateParentWindowView, BasePageView basePageView, int ıd)
        {
            UpdateParentWindowView = updateParentWindowView;
            BasePageView = basePageView;
            Id = ıd;
            baseRepositories = new BaseRepositories<Parent>();

            CloseCommand = new MyRealyCommand(CloseProgramCommand);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction, CanUpdateCommandFunction);

            var parent = baseRepositories.GetEntity(Id);

            UpdateParentWindowView.ComboBoxFirstName.Text = parent.FirstName;
            UpdateParentWindowView.ComboBoxLastName.Text = parent.LastName;
            UpdateParentWindowView.ComboBoxPhone.Text = parent.Phone;
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

            baseRepositories.Save();

            ParentView parentView = new ParentView();
            parentView.DataContext = new ParentViewModel(BasePageView);
            BasePageView.BasePageFream.Navigate(parentView);

            UpdateParentWindowView.Close();


        }


        public bool CanUpdateCommandFunction(object? par)
        {
            string firstName = UpdateParentWindowView.ComboBoxFirstName.Text;
            string lastName = UpdateParentWindowView.ComboBoxLastName.Text;
            string phone = UpdateParentWindowView.ComboBoxPhone.Text;


            if (!Regex.IsMatch(phone , @"^\d{3}-\d{3}-\d{2}-\d{2}$")) { return false; }

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
