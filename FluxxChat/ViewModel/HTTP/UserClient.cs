using FluxxChat.Model;
using FluxxChat.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace FluxxChat.ViewModel.HTTP
{
    public class UserClient
    {
        private readonly HttpClient _httpClient;
        private string login;
        private string password;


        public UserClient(string _login, string _password)
        {
            _httpClient = new HttpClient();
            login = _login;
            password = _password;
        }

        public async Task<User> AuthorizeUser()
        {

            using (var httpClient = new HttpClient())
            {
                var user = new
                {
                    Login = login,
                    Password = password
                };

                var requestContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("http://localhost:5109/api/users/authorization", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var userInfo = JsonConvert.DeserializeObject<User>(responseBody);
                    return userInfo;
                }
                else
                {
                    ShowCustomMessageBox.Show("Ошибка авторизации", "Не удалось найти пользователя.\n\nПроверьте правильность введенных данных и попробуйте авторизоваться снова.");
                    //MessageBox.Show("Ошибка подключения к серверу, обратитесь к администратору " + response.ReasonPhrase, "HTTP Error");
                    return null;
                }
            }         
        }
    }
}
