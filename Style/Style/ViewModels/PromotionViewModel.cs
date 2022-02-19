using Style.APIs;
using Style.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Style.ViewModels
{
    class PromotionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Promotion> myp
        {
            get
            {
                return mypp;
            }

            set
            {
                mypp = value;
                var args = new PropertyChangedEventArgs(nameof(myp));
                PropertyChanged?.Invoke(this, args);
            }

        }
        APIservice apiservice;
        public ObservableCollection<Promotion> mypp;

        public PromotionViewModel()
        {
            myp = new ObservableCollection<Promotion>();
            apiservice = new APIservice();
            GetPro();
        }
        async void GetPro()
        {
            myp = await apiservice.GetPromote();
        }
    }
}
