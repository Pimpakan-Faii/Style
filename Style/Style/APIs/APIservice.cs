using Newtonsoft.Json;
using Style.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Style.APIs
{
    class APIservice
    {
        HttpClient client;
        public APIservice()
        {
            client = new HttpClient();
        }
        public async Task<ObservableCollection<Promotion>> GetPromote()
        {
            ObservableCollection<Promotion> rest = null;

            try
            {
                var response = await client.GetAsync("http://10.0.2.2:53432/api/CouponsAPI");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    rest = JsonConvert.DeserializeObject<ObservableCollection<Promotion>>(content);
                    return rest;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return null;
        }
        public async Task<ObservableCollection<Canteen>> GetNewrcanteens()
        {
            ObservableCollection<Canteen> rest1 = null;

            try
            {
                var response1 = await client.GetAsync("http://10.0.2.2:53432/api/StoresAPI");
                if (response1.IsSuccessStatusCode)
                {
                    var content1 = await response1.Content.ReadAsStringAsync();
                    rest1 = JsonConvert.DeserializeObject<ObservableCollection<Canteen>>(content1);
                    return rest1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return null;
        }
        public async Task<ObservableCollection<Comment>> GetComments(string id)
        {
            ObservableCollection<Comment> cm = null;

            try
            {
                var response1 = await client.GetAsync("http://10.0.2.2:53432/api/CommentsAPI/"+id);
                if (response1.IsSuccessStatusCode)
                {
                    var content1 = await response1.Content.ReadAsStringAsync();
                    cm = JsonConvert.DeserializeObject<ObservableCollection<Comment>>(content1);
                    return cm;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return null;
        }
        
        public async Task<ObservableCollection<Protected>> GetProtect()
        {
            ObservableCollection<Protected> Protect = null;

            try
            {
                var response = await client.GetAsync("http://10.0.2.2:53432/api/SafesAPI");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Protect = JsonConvert.DeserializeObject<ObservableCollection<Protected>>(content);
                    return Protect;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return null;
        }
        /*public async Task<ObservableCollection<Canteen>> GetUser()
        {
            ObservableCollection<Canteen> rest = null;
            var username = Preferences.Get("username", "");
            try
            {
                var response = await client.GetAsync("http://10.0.2.2:1472/api/StoresAPI?username=" + username);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    rest = JsonConvert.DeserializeObject<ObservableCollection<Canteen>>(content);
                    return rest;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return null;
        }*/
        public async Task<bool> Register(Register Item)
        {

            try
            {
                string json = JsonConvert.SerializeObject(Item);
                StringContent sContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://10.0.2.2:4324/api/Account/Register", sContent);

                return response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
         public async Task<bool> Logout()
        {

            try
            {
                var access_token = Preferences.Get("access_token", "");
                var token_type = Preferences.Get("token_type", "");

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);

                var response = await client.PostAsync("http://10.0.2.2:4324/api/Account/Logout", null);

                return response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
        public async Task<bool> Login(Login login)
        {
            User Items = null;
            try
            {
                var dict = new Dictionary<string, string>();
                dict.Add("Content-Type", "application/x-www-form-urlencode");
                dict.Add("grant_type", "password");
                dict.Add("username", login.Email);
                dict.Add("password", login.Password);

                var response = await client.PostAsync("http://10.0.2.2:4324/token", new FormUrlEncodedContent(dict));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<User>(content);
                    Preferences.Set("username", Items.userName);
                    Preferences.Set("token_type", Items.token_type);
                    Preferences.Set("access_token", Items.access_token);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return false;
        }
        public async Task<bool> AddComment(Comment Item)
        {

            try
            {
                string json = JsonConvert.SerializeObject(Item);
                StringContent sContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://10.0.2.2:53432/api/CommentsAPI", sContent);

                return response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
   

    }

}
