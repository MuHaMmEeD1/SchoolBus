using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.DTOS;
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
    public class CarViewModel
    {
        public BasePageView basePageView { get; set; }
        BaseRepositories<Car> baseRepositories { get; set; }
        public List<CarPageListView> carPageListViews { get; set; }


        public MyRealyCommand AddCommand { get; set; }
        public MyRealyCommand RemoveCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }


        public CarViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
            baseRepositories = new BaseRepositories<Car>();
            carPageListViews = new List<CarPageListView>();

            AddCommand = new MyRealyCommand(AddCommandFunction, CanAddCommandFunction);
            RemoveCommand = new MyRealyCommand(RemoveCommandFunction);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction);

            CarPageDTOS();
        }



        void CarPageDTOS()
        {
            var cars = baseRepositories.GetAllEntity();
            foreach (var car in cars)
            {
                if(car.Id == 0) { continue; }

                carPageListViews.Add(
                    new CarPageListView()
                    {
                        Id = car.Id,
                        Marka = car.Marka,
                        Model = car.Model,
                        FullPlace = car.FullPlace,
                        Capacity = car.Capacity,
                        CarNumber = car.CarNumber,
                    }
                    );


            }




        }

        public void AddCommandFunction(object? par)
        {

            StackPanel stackPanel = par as StackPanel;

            var Parents = baseRepositories.GetAllEntity();

            int Id = 0;
            ComboBox ModelComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox MarkaComboBox = stackPanel.Children[1] as ComboBox;
            ComboBox CarNumberComboBox = stackPanel.Children[2] as ComboBox;
            ComboBox CapactyComboBox = stackPanel.Children[3] as ComboBox;

            var entitys = baseRepositories.GetAllEntity();
            Id = entitys[entitys.Count - 1].Id+1;

            baseRepositories.Add(new Car()
            {
                Id = Id,
                Model = ModelComboBox.Text,
                Marka = MarkaComboBox.Text,
                CarNumber = CarNumberComboBox.Text,
                Capacity = int.Parse(CapactyComboBox.Text)

            }); ;
            baseRepositories.Save();

            CarView carView = new CarView();
            carView.DataContext = new CarViewModel(basePageView);
            basePageView.BasePageFream.Navigate(carView);
        }

        public bool CanAddCommandFunction(object? par)
        {
            StackPanel stackPanel = par as StackPanel;

            var Parents = baseRepositories.GetAllEntity();


            ComboBox ModelComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox MarkaComboBox = stackPanel.Children[1] as ComboBox;
            ComboBox CarNumberComboBox = stackPanel.Children[2] as ComboBox;
            ComboBox CapactyComboBox = stackPanel.Children[3] as ComboBox;

            if(ModelComboBox.Text.Length < 3 || ModelComboBox.Text.Length > 19) { return false; }   
            if(MarkaComboBox.Text.Length < 3 || MarkaComboBox.Text.Length > 19) { return false; }   
            if(!Regex.IsMatch(CarNumberComboBox.Text, @"^\d{2}-[A-Za-z]{2}-\d{3}$")) { return false; }
            if(Regex.IsMatch(CapactyComboBox.Text, @"^\d+$")){
                int cp = int.Parse(CapactyComboBox.Text);
                if(cp<10 || cp > 40) { return false; }
            }
            else { return false; }
            return true;
        }


        public void RemoveCommandFunction(object? par)
        {
            Label label = par as Label;
            int Id = int.Parse(label.Content.ToString());



            var entity = baseRepositories.GetEntity(Id);


            BaseRepositories<Driver> drRepo = new BaseRepositories<Driver>();
            var drivers = drRepo.GetAllEntity();

            foreach (var dri in drivers)
            {
                if(entity.Id == dri.CarId) { dri.CarId = 0; break; }
            }

            drRepo.Save();
            baseRepositories.Delete(entity);
            baseRepositories.Save();

            CarView carView = new CarView();
            carView.DataContext = new CarViewModel(basePageView);
            basePageView.BasePageFream.Navigate(carView);
        }


        public void UpdateCommandFunction(object? par)
        {
            Label label = par as Label;
            int Id = int.Parse(label.Content.ToString());


            UpdateCarWindowView updateCarWindowView = new UpdateCarWindowView();
            updateCarWindowView.DataContext = new UpdateCarWindowViewModel(updateCarWindowView, basePageView, Id);
            updateCarWindowView.Show();

        }

    }
}
