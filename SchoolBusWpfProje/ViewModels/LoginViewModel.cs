using SchoolBusWpfProje.RealyCommands;
using SchoolBusWpfProje.View;
using SchoolBusWpfProje.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusAppp.ViewModel.Pages
{
    public class LoginViewModel
    {
        BaseFileView baseWindowView { get; set; }
        LoginView loginView { get; set; }

        public MyRealyCommand LoginCommand { get; set; }
        public MyRealyCommand CloseCommand { get; set; }

        public LoginViewModel(BaseFileView baseFileView, LoginView loginView)
        {
            this.baseWindowView = baseFileView;
            this.loginView = loginView;

            CloseCommand = new MyRealyCommand(CloseCommandFunction);
            LoginCommand = new MyRealyCommand(LoginCommandFunction);

        }


        public void LoginCommandFunction(object? par)
        {

            if (loginView.ComboBoxLogin.Text == "login" && loginView.ComboBoxPassword.Text == "123")
            {
                BasePageView basePageView = new BasePageView(baseWindowView);

                baseWindowView.BaseFream.Navigate(basePageView);
            }


        }
        public void CloseCommandFunction(object? par) { baseWindowView.Close(); }
    }
}
