using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.ViewModels
{
    public class BasePageViewModel
    {
        public BaseFileView baseFileView { get; set; }
        public BasePageView basePageView { get; set; }

        public MyRealyCommand CloseCommand { get; set; }
        public MyRealyCommand CarChangeCommand { get; set; }
        public MyRealyCommand ClassChangeCommand { get; set; }
        public MyRealyCommand DriverChangeCommand { get; set; }
        public MyRealyCommand ParentChangeCommand { get; set; }
        public MyRealyCommand ReaderChangeCommand { get; set; }
        public MyRealyCommand StudentChangeCommand { get; set; }

        public BasePageViewModel(BaseFileView baseFileView, BasePageView basePageView)
        {
            this.baseFileView = baseFileView;
            this.basePageView = basePageView;

            basePageView.BasePageFream.Navigate(new ReaderView() { DataContext = new ReaderViewModel(basePageView) });



            CloseCommand = new MyRealyCommand(CloseProgramCommand);
            CarChangeCommand = new MyRealyCommand(CarChangeCommandFunction);
            ClassChangeCommand = new MyRealyCommand(ClassChangeCommandFunction);
            DriverChangeCommand = new MyRealyCommand(DriverChangeCommandFunction);
            ParentChangeCommand = new MyRealyCommand(ParentChangeCommandFunction);
            ReaderChangeCommand = new MyRealyCommand(ReaderChangeCommandFunction);
            StudentChangeCommand = new MyRealyCommand(StudentChangeCommandFunction);
        }



        public void CloseProgramCommand(object? par)
        {
            baseFileView.Close();
        }

        public void CarChangeCommandFunction(object? par)
        {
           basePageView.BasePageFream.Navigate(new CarView() { DataContext = new CarViewModel(basePageView) });
        }

        public void ClassChangeCommandFunction(object? par)
        {
            basePageView.BasePageFream.Navigate(new ClassView() { DataContext = new ClassViewModel(basePageView) });
        }

        public void DriverChangeCommandFunction(object? par)
        {
            basePageView.BasePageFream.Navigate(new DriverView() { DataContext = new DriverViewModel(basePageView) });
        }

        public void ParentChangeCommandFunction(object? par)
        {
            basePageView.BasePageFream.Navigate(new ParentView() { DataContext = new ParentViewModel(basePageView) });
        }

        public void ReaderChangeCommandFunction(object? par)
        {
            basePageView.BasePageFream.Navigate(new ReaderView(){DataContext = new ReaderViewModel(basePageView)});
        }

        public void StudentChangeCommandFunction(object? par)
        {
            basePageView.BasePageFream.Navigate(new StudentView(){DataContext = new StudentViewModel(basePageView)});
        }









    }
}

