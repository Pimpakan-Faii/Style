using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Style.APIs;
using Style.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Style.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CanteenDetail : ContentPage
    {
        Comment comment;
        APIservice apiservice;
        public CanteenDetail()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            apiservice = new APIservice();
            comment = new Comment();
            comment.Id = "1";
            comment.StoreId = CanteenId.Text;
            comment.UserName = Preferences.Get("username", "");
            comment.Text = TEXENTER.Text;

            var response = await apiservice.AddComment(comment);

            if (response)
            {
                await Application.Current.MainPage.DisplayAlert("Comment", "Success!!!", "OK");
                TEXENTER.Text = " ";
            }

        }
    }
}