using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParentsMobile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ParentsMobile.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterUserAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://childcare.outstandservices.pt/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginUserAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",userName),
                new KeyValuePair<string, string>("password",password),
                new KeyValuePair<string, string>("grant_type","password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://childcare.outstandservices.pt/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var jwt = await response.Content.ReadAsStringAsync();

            //jwt contem o accessToken, mas não é o AccessToken

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

            var accessToken = jwtDynamic.Value<string>("access_token");

            Debug.WriteLine(jwt);

            return accessToken;


        }

        public async Task<List<Childrens>> GetChildrenAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //var json = await client.GetStringAsync("http://childcare.outstandservices.pt/api/Childrens/ForCurrentParent");
            var json = await client.GetStringAsync("http://childcare.outstandservices.pt/api/Childrens");

            var childrenList = JsonConvert.DeserializeObject<List<Childrens>>(json);

            return childrenList;
        }

        public async Task PostChildrenAsync(Childrens children, string accessToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(children);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://childcare.outstandservices.pt/api/Childrens", content);
        }
    }
}
