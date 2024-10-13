using FluxxChat.Model;
using FluxxChat.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                try 
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
                catch
                {
                    ShowCustomMessageBox.Show("Ошибка авторизации", "Не удалось установить соединение с сервером.");
                    return null;
                }
                
            }         
        }

        public async Task<User> RegisterUser()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var user = new
                    {
                        Login = login,
                        Password = password
                    };

                    var requestContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("http://localhost:5109/api/users/registration", requestContent);

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
                catch
                {
                    ShowCustomMessageBox.Show("Ошибка авторизации", "Не удалось установить соединение с сервером.");
                    return null;
                }

            }
        }

        public async Task<string> UploadAvatar(string filePath)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var form = new MultipartFormDataContent();

                    // Удалите строку, где вы добавляете userId в форму // form.Add(new StringContent(Settings.id.ToString()), "userId");

                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    var fileContent = new StreamContent(fileStream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    form.Add(fileContent, "file", Path.GetFileName(filePath));

                    // Передайте userId как параметр строки запроса
                    var response = await httpClient.PostAsync($"http://localhost:5109/api/users/upload-avatar?userId={Settings.id}", form);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<User>(responseBody);
                        return result.Uri.ToString();
                    }
                    else
                    {
                        ShowCustomMessageBox.Show("Ошибка загрузки", "Не удалось загрузить изображение.");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ShowCustomMessageBox.Show("Ошибка загрузки", $"Не удалось установить соединение с сервером. Ошибка: {ex.Message}");
                    return null;
                }
            }
        }

    }
}
