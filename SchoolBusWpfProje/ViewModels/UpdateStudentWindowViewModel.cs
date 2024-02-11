using SchoolBusModel.Entitys.normul;
using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.ViewModels
{
    public class UpdateStudentWindowViewModel
    {

        UpdateStudentWindowView updateStudentWindowView{  get; set; }
        BasePageView BasePageView { get; set; }
        int StudentId { get; set; }

        public MyRealyCommand CloseCommand { get; set; }
        public MyRealyCommand UpdateCommand { get; set; }

        public UpdateStudentWindowViewModel(UpdateStudentWindowView updateStudentWindow, BasePageView basePageView, int studentId)
        {
            updateStudentWindowView = updateStudentWindow;
            BasePageView = basePageView;
            StudentId = studentId;


            CloseCommand = new MyRealyCommand(CloseProgramCommand);
        }


        

        








        public void CloseProgramCommand(object? par)
        {
            updateStudentWindowView.Close();
        }

    }
}
