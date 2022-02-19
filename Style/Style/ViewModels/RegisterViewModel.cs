using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Style.APIs;
using Style.Model;
using Xamarin.Forms;

namespace Style.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Register Register { get; set; }

        APIservice apiservice;
        public Command Back { get; }

        public Command Registercommand { get; }

        public RegisterViewModel()
        {
            Register = new Register();
            apiservice =new APIservice();

            Back = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.Login());
            });

            Registercommand = new Command(async () =>
            {

                var response = await apiservice.Register(Register);

                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Register", "Register Successfull", "Ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Register", "Fail!!", "Ok");

                }
            });
        }
        
    }
}
