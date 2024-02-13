using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.View;
using ShcoolBusDataAccess.Repositoriess.Abstructs;
using ShcoolBusDataAccess.Repositoriess.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.ViewModels
{
    public class UpdateCarWindowViewModel
    {

        UpdateCarWindowView updateCarWindowView { get; set; }
        BasePageView basePageView { get; set; }
        int Id { get; set; }

        public MyRealyCommand CloseCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }

        BaseRepositories<Car> baseRepositories { get; set; }

        public UpdateCarWindowViewModel(UpdateCarWindowView updateCarWindowView, BasePageView basePageView, int ıd)
        {
            this.updateCarWindowView = updateCarWindowView;
            this.basePageView = basePageView;
            Id = ıd;
            baseRepositories = new BaseRepositories<Car>();

            CloseCommand = new MyRealyCommand(CloseProgramCommand);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction, CanUpdateCommandFunction);

            var car = baseRepositories.GetEntity(Id);


            updateCarWindowView.ComboBoxModel.Text = car.Model;
            updateCarWindowView.ComboBoxMarka.Text = car.Marka;
            updateCarWindowView.ComboBoxCapacity.Text = car.Capacity.ToString();
            updateCarWindowView.ComboBoxCarNumber.Text = car.CarNumber.ToString();




        }


        public void UpdateCommandFunction(object? par)
        {
            string model = updateCarWindowView.ComboBoxModel.Text;
            string marka = updateCarWindowView.ComboBoxMarka.Text;
            string capacity = updateCarWindowView.ComboBoxCapacity.Text;
            string carNumber = updateCarWindowView.ComboBoxCarNumber.Text;

            var entity = baseRepositories.GetEntity(Id);
            entity.Model = model;
            entity.Marka = marka;
            entity.CarNumber = carNumber;
            entity.Capacity = int.Parse(capacity);
            baseRepositories.Save();

            CarView carView = new CarView();
            carView.DataContext = new CarViewModel(basePageView);
            basePageView.BasePageFream.Navigate(carView);

            updateCarWindowView.Close();

        }


        public bool CanUpdateCommandFunction(object? par)
        {
            var entity = baseRepositories.GetEntity(Id);

            string model = updateCarWindowView.ComboBoxModel.Text;
            string marka = updateCarWindowView.ComboBoxMarka.Text;
            string capacity = updateCarWindowView.ComboBoxCapacity.Text;
            string carNumber = updateCarWindowView.ComboBoxCarNumber.Text;

            if(model.Length < 3 ||  model.Length > 20) { return false; }
            if(marka.Length < 3 || marka.Length > 20) { return false; }
            if (!Regex.IsMatch(carNumber, @"^\d{2}-[A-Za-z]{2}-\d{3}$")) { return false; }
            if (Regex.IsMatch(capacity, @"^\d+$"))
            {
                int cp = int.Parse(capacity);
                if (cp < 10 || cp > 40 || cp < entity.FullPlace) { return false; }
            }
            else { return false; }

            return true;
        }





        public void CloseProgramCommand(object? par)
        {
            updateCarWindowView.Close();
        }




    }
}
