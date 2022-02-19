using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Style.ViewModels
{
    class test : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string email;
         string show;

    
    public Command Showcommand
    {
        get;
    }
    
    public string Email
    {
        get => email;

        set
        {
            email = value;
            var agrs = new PropertyChangedEventArgs(nameof(Email));
            PropertyChanged?.Invoke(this, agrs);
        }
    }


    public string Show
    {
        get => show;
        set
        {
            show = value;
            var agrs = new PropertyChangedEventArgs(nameof(Show));
            PropertyChanged?.Invoke(this, agrs);
        }
    }
    public test()
    {
      

        Showcommand = new Command(() =>
        {
            this.Show = "Username: " + this.Email;

        });



    }
}
}

