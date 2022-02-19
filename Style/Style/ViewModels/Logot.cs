using Style.APIs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Style.ViewModels
{
    class Logot : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public Command Logout { get; }
        APIservice aPIservice;

        public Logot()
        {
            aPIservice = new APIservice();
            Logout = new Command(async () =>
            {
                var response = await aPIservice.Logout();
                if (response)
                {
                    Application.Current.MainPage = new NavigationPage(new View.Login());
                }
            }
           );
        }
    }
}
