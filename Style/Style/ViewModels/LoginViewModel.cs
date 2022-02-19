using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Style.Model;
using Xamarin.Forms;
using Style.APIs;

namespace Style.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Login Login { get; set; }
        string result;
        APIservice aPIservice;
        public string Result
        {

            get => result;
            set
            {
                result = value;
                var args = new PropertyChangedEventArgs(nameof(Result));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public LoginViewModel()
        {
            aPIservice = new APIservice();
            Login = new Login();
            LoginCommand = new Command(async () =>
            {
                var response = await aPIservice.Login(Login);
                if (response)
                {
                    Result = "Success";
                    Application.Current.MainPage = new View.MyTabbedPage1();

                }
                else
                {
                    Result = "Fail!!!";
                }
            });
            RegisterCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.Register());
            });
        }
    }
}
