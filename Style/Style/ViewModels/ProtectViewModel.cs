using Style.Model;
using Style.APIs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Style.ViewModels
{
    class ProtectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Protected> myprotects
        {
            get
            {
                return myprots;
            }

            set
            {
                myprots = value;
                var args = new PropertyChangedEventArgs(nameof(myprotects));
                PropertyChanged?.Invoke(this, args);
            }

        }
        APIservice aPIservice;
        ObservableCollection<Protected> myprots;
        public Command SelectedCommand { get; }
       
        public Protected selectedProt { get; set; }
        public ProtectViewModel()
        {
            myprotects = new ObservableCollection<Protected>();
            aPIservice = new APIservice();
            GetNewProtects();
            SelectedCommand = new Command(async () =>
            {
               

                //var sendVar = new { selectedCanteen = selectedCanteen, Close = Close, Add = AddCommnad };
                var ProtDetail = new View.ProtectDetail
                {
                    BindingContext = selectedProt

                };

                await Application.Current.MainPage.Navigation.PushModalAsync(ProtDetail);
            });
        }
        async void GetNewProtects()
        {
            myprotects = await aPIservice.GetProtect();
        }
    }
}