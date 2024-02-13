using SchoolBusModel.Entitys.Concreds;
using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.DTOS;
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
    public class ClassViewModel
    {

        public BasePageView basePageView { get; set; }
        BaseRepositories<Class> BaseRepositories { get; set; }
        public List<ClassPageListView> classPageListViews { get; set; }
        public MyRealyCommand AddCommand { get; set; }
        public MyRealyCommand RemoveCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }


        public ClassViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
            BaseRepositories = new BaseRepositories<Class>();
            classPageListViews=new List<ClassPageListView>();
            AddCommand = new MyRealyCommand(AddCommandFunction, CanAddCommandFunction);
            RemoveCommand = new MyRealyCommand(RemoveCommandFunction);
            UpdateCommand = new MyRealyCommand(UpdateCommandFunction);

            ClassPageDTOSChange();

        }




        void ClassPageDTOSChange()
        {
            var classs = BaseRepositories.GetAllEntity();

            for (int i = 0; i < classs.Count; i++)
            {
                if (classs[i].Id == 0) { continue; }

                int count = 0;
                count = classs[i].Students is null ? 0 : classs[i].Students.Count;
                classPageListViews.Add(new ClassPageListView() { Id = classs[i].Id,
                                                                 Name = classs[i].Name ,
                                                                 StudentsCount = count
                });
            }



        }



        public bool CanAddCommandFunction(object? par)
        {
            ComboBox comboBox = par as ComboBox;

            if (comboBox.Text.Length > 20 || comboBox.Text.Length < 2) { return false; }


            return true;
        }
        public void AddCommandFunction(object? par)
        {
            ComboBox comboBox = par as ComboBox;

            var Classs = BaseRepositories.GetAllEntity();
            int id = Classs[Classs.Count - 1].Id+1;
            Classs.Add(new Class() { Id = 3, Name = comboBox.Text });

            BaseRepositories.Add(Classs[Classs.Count-1]);
            BaseRepositories.Save();

            ClassView classView = new ClassView();
            classView.DataContext = new ClassViewModel(basePageView);
            basePageView.BasePageFream.Navigate(classView);

        }


        public void RemoveCommandFunction(object? par)
        {
            Label label = par as Label;
            int id = int.Parse(label.Content.ToString());

            var Classs = BaseRepositories.GetAllEntity();

            foreach (var Class in Classs) {

                if (Class.Id == id) { 
                
                    foreach (var student in Class.Students)
                    {
                        student.ClassId = 0;
                        student.CarId = 0;
                        BaseRepositories<ParentsStudents> baseRepositories = new BaseRepositories<ParentsStudents>();

                        foreach (var item in student.ParentsStudents)
                        {
                            baseRepositories.Delete(item);
                        }
                    }

                    BaseRepositories.Delete(Class);
                    BaseRepositories.Save();
                    break;
                }

            }

            ClassView classView = new ClassView();
            classView.DataContext = new ClassViewModel(basePageView);
            basePageView.BasePageFream.Navigate(classView);


        }


        public void UpdateCommandFunction(object? par)
        {
            Label label = par as Label;
            int Id = int.Parse(label.Content.ToString());

            UpdateClassWindowView updateClassWindowView = new UpdateClassWindowView();
            updateClassWindowView.DataContext = new UpdateClassWindowViewModel(updateClassWindowView, basePageView, Id);
            updateClassWindowView.Show();

        }

    }
}
