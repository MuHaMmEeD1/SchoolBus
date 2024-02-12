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
    public class ParentViewModel
    {
        public BasePageView basePageView { get; set; }
        BaseRepositories<Parent> baseRepositories { get; set; }
        public List<ParentPageListView> parentPageListViews { get; set; }

        public MyRealyCommand RemoveCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }
        public MyRealyCommand AddCommand { get; set; }




        public ParentViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
            baseRepositories = new BaseRepositories<Parent>();
            parentPageListViews = new List<ParentPageListView>();
            AddCommand = new MyRealyCommand(AddCommandFunction, CanAddCommandFunction);
            RemoveCommand = new MyRealyCommand(RemoveCommandFunction);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction);

            ParentPageDTOS();
        }



        void ParentPageDTOS()
        {
            var parents = baseRepositories.GetAllEntity();
            foreach (var parent in parents)
            {
                parentPageListViews.Add(
                            new ParentPageListView()
                            {
                                Id = parent.Id,
                                FirstName = parent.FirstName,
                                LastName = parent.LastName,
                                Phone = parent.Phone,
                            });
            }




        }
        
        public void AddCommandFunction(object? par)
        {

            StackPanel stackPanel = par as StackPanel;

            var Parents = baseRepositories.GetAllEntity();


            ComboBox FirstNameComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox LastNameComboBox1 = stackPanel.Children[1] as ComboBox;
            ComboBox PhoneComboBox2 = stackPanel.Children[2] as ComboBox;



            baseRepositories.Add(new Parent()
            {
                FirstName = FirstNameComboBox.Text,
                LastName = LastNameComboBox1.Text,
                Phone = PhoneComboBox2.Text
            });
            baseRepositories.Save();

            ParentView parentView = new ParentView();
            parentView.DataContext = new ParentViewModel(basePageView);
            basePageView.BasePageFream.Navigate(parentView);
        }

        public bool CanAddCommandFunction(object? par)
        {

            StackPanel stackPanel = par as StackPanel;

            var Parents = baseRepositories.GetAllEntity();


            ComboBox FirstNameComboBox = stackPanel.Children[0] as ComboBox;
            ComboBox LastNameComboBox1 = stackPanel.Children[1] as ComboBox;
            ComboBox PhoneComboBox2 = stackPanel.Children[2] as ComboBox;

            if(!Regex.IsMatch(PhoneComboBox2.Text, @"^\d{3}-\d{3}-\d{2}-\d{2}$")) { return false; }

            string firStr = LastNameComboBox1.Text;
            string lasStr = FirstNameComboBox.Text;

            if(firStr.Length < 3 || firStr.Length > 29) { return false; }
            if(lasStr.Length < 3 || lasStr.Length > 29) { return false; }


            return true;
        }


        public void RemoveCommandFunction(object? par)
        {
            Label label = par as Label;
            int id = int.Parse(label.Content.ToString());

            var entity = baseRepositories.GetEntity(id);
            baseRepositories.Delete(entity);
            baseRepositories.Save();

            ParentView parentView = new ParentView();
            parentView.DataContext = new ParentViewModel(basePageView);
            basePageView.BasePageFream.Navigate(parentView);
        }


        public void UpdateCommandFunction(object? par)
        {
            Label label = par as Label;
            int Id = int.Parse(label.Content.ToString());


            UpdateParentWindowView updateParentWindowView = new UpdateParentWindowView();
            updateParentWindowView.DataContext = new UpdateParentWindowViewModel(updateParentWindowView, basePageView, Id);
            updateParentWindowView.Show();


        }









    }
}

