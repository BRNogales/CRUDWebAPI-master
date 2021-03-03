using CRUDWebAPI.Clases;
using CRUDWebAPI.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUDWebAPI
{   
    class ApiServices
    {

        internal async Task<string> LoginAsync(string employee, string password)
        {
                var keyValues = new List<KeyValuePair<string, string>>
    {
        new KeyValuePair<string, string>("employee",employee),
        new KeyValuePair<string, string>("password",password),
        new KeyValuePair<string, string>("grant_type","password")


    };

                var request = new HttpRequestMessage(HttpMethod.Post, "http://138.197.221.203/api/v1/login_check");
                request.Content = new FormUrlEncodedContent(keyValues);
                HttpClient client = new HttpClient();
                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                JObject jdynamic = JsonConvert.DeserializeObject<dynamic>(content);
                var accessToken = jdynamic.Value<string>("token");
                //await Application.Current.MainPage.DisplayAlert("Alert", content, "OK");
                Debug.WriteLine(content);
                Settings.token = content;
                Settings.token = accessToken;
                return accessToken;
        
        }

        public async Task<List<RutasdeAuditores>> GetClientesAsync(string token , string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", token);

            var json = await client.GetStringAsync($"http://138.197.221.203/api/v1/users/{id}/audit_assignments?page=1&audited=false");

            var RutasdeAuditores = JsonConvert.DeserializeObject<List<RutasdeAuditores>>(json);

            return RutasdeAuditores;
        }

        public async Task<List<enfriador>> GetcoolersTypeAsync(string token, string idcliente)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", token);

            var json = await client.GetStringAsync($"http://138.197.221.203/api/v1/clients/{idcliente}/coolers?page=1");

            var coolers = JsonConvert.DeserializeObject<List<enfriador>>(json);
    
            return coolers;


        }
        public async Task<List<enfriador>> GetcoolersAsync(string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", token);

            var json = await client.GetStringAsync($"http://138.197.221.203/api/v1/types?entity=cooler&page=1");

            var coolers = JsonConvert.DeserializeObject<List<enfriador>>(json);

            return coolers;
        }
    }
}
