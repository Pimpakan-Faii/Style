using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Style
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new View.Login());
            MainPage = new NavigationPage(new View.CanteenList());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
