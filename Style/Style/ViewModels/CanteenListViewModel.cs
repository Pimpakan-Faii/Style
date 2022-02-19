using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Style.Model;
using System.ComponentModel;
using Xamarin.Forms;
using Style.APIs;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;

namespace Style.ViewModels
{
    class CanteenListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Search word { get; set; }

        APIservice apiservice;

        public getComments getComments { get; set; }
        public InputComment TextInputComments { get; set; }
        public Comment Mycoments { get; set; }
        public Popular YodNi { get; set; }
        public Usercurrent Current { get; set; }

        public ObservableCollection<Popular> pW;

        public ObservableCollection<Comment> mycoms;

        public ObservableCollection<Canteen> TestCan;
        public ObservableCollection<Canteen> my
        {
            get
            {
                return mynewrcanteens;
            }

            set
            {
                mynewrcanteens = value;
                var args = new PropertyChangedEventArgs(nameof(my));
                PropertyChanged?.Invoke(this, args);
            }

        }
        public ObservableCollection<Canteen> mynewrcanteens;

        public ObservableCollection<Popular> myPop
        {
            get
            {
                return pW;
            }

            set
            {
                pW = value;
                var args = new PropertyChangedEventArgs(nameof(myPop));
                PropertyChanged?.Invoke(this, args);
            }

        }
        public ObservableCollection<Comment> mycm
        {
            get
            {
                return mycoms;
            }

            set
            {
                mycoms = value;
                var args = new PropertyChangedEventArgs(nameof(mycm));
                PropertyChanged?.Invoke(this, args);
            }

        }

        public Command SelectedCommand { get; }
        public Command ShowCommand { get; }

        public Command Close { get; }
        public Command AddCommnad { get; }
        public Canteen selectedCanteen { get; set; }

        public ICommand PerformSearch { get; }

        public CanteenListViewModel()
        {
            my = new ObservableCollection<Canteen>();
            

            apiservice = new APIservice();
            word = new Search();
            mycm = new ObservableCollection<Comment>();
            GetNewcanteens();

            SelectedCommand = new Command(async() =>
            {
                await GetComments();

                var sendVar = new { selectedCanteen = selectedCanteen, Close = Close, Add = AddCommnad ,mycm = mycm};
                var ProdDetail = new View.CanteenDetail
                {
                    BindingContext = new {selectedCanteen , mycm , AddCommnad}
                };
 
                await Application.Current.MainPage.Navigation.PushModalAsync(ProdDetail);
            });

            PerformSearch = new Command<string>((string query) =>
            {
                if (!String.IsNullOrEmpty(word.Text))
                {
                  
                     my = new ObservableCollection<Canteen>(TestCan.Where(x => x.name.ToLower().Contains(word.Text.Trim().ToLower())));
                }
                else if(word.Text.Equals(""))
                {
                   // my = new ObservableCollection<Canteen>(TestCan.ToList());
                }
            });

            Current = new Usercurrent();
            Current.getUser = "สวัสดี "+Preferences.Get("username", "");
           
            AddCommnad = new Command(async () =>
            {
                //TextInputComments = new InputComment();
                //TextInputComments.TextComments = getComments.getText;

                Mycoments = new Comment();
                Mycoments.Id = "1";
                Mycoments.Text = TextInputComments.TextComments;
                Mycoments.StoreId = selectedCanteen.ProductId;
                Mycoments.UserName = Preferences.Get("username", "");

                var response = await apiservice.AddComment(Mycoments);

                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Comment", "Success!!!", "OK");
                }
            });

            /* YodNi = new Popular();
             for(var i = 0; i<=3; i++)
             {
                  GetNewcanteens();
             }*/
            /* string[] data = new string[3];
             data[0] = "a";
             data[1] = "b";
             data[2] = "c";
             foreach(var getdata in data)
             {
                 YodNi.niyom = getdata;
             }*/

            /* Canteen data = new Canteen();
             var test = data.username = Preferences.Get("username", "");

             Console.WriteLine("FOundddddd"+test);
             
             /* Close = new Command(async () =>
              {
                  await Application.Current.MainPage.Navigation.PopModalAsync();
              });*/
        }
        async void GetNewcanteens()
        {
            my = await apiservice.GetNewrcanteens();


            TestCan = mynewrcanteens;
        }
        
        async Task GetComments()
        {
            mycm = await apiservice.GetComments(selectedCanteen.ProductId);
        }
    }
    }

