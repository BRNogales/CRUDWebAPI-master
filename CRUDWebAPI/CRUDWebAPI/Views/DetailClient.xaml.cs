using CRUDWebAPI.Clases;
using CRUDWebAPI.ModelViewsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailClient : ContentPage
    {
        public DetailClient(string name, string tradename,string routenumber, string id, string idudit)
        {
            InitializeComponent();
            imgdetail.Source = ImageSource.FromResource("CRUDWebAPI.img.publico-objetivo.png");
            nombre_client.Text = name;
            no_comercial.Text = tradename;
            ruta.Text = routenumber;
            idclient.Text = id;
            idaudit.Text = idudit;
            picketipocliente.SelectedIndexChanged += Picketipocliente_SelectedIndexChanged;
            btna.Clicked += Btna_Clicked;
            OnBackButtonPressed();
            btnvolver.Clicked += Btnvolver_Clicked;
            btnmap.Clicked += Btnmap_Clicked;
        }

        private void Btnmap_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btnvolver_Clicked(object sender, EventArgs e)
        {
            btnvolver.IsEnabled = false;
            App.Current.MainPage = new CargarClientes();
        }

        private async void Btna_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.Properties["idcliente"] = idclient.Text.ToString();
            Xamarin.Forms.Application.Current.Properties["idaudit"] = idaudit.Text.ToString();
            Xamarin.Forms.Application.Current.Properties["typeclientevaluation"] = picketipocliente.SelectedItem.ToString();
            btna.IsEnabled = false;
            Cliente cliente1 = new Cliente();
            cliente1.name = nombre_client.Text;
            cliente1.tradename = no_comercial.Text;
            cliente1.type = typeclient.Text;

            HttpClient cliente = new HttpClient();
            var Token = Settings.token;
            var json = JsonConvert.SerializeObject(cliente1);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var token = JsonConvert.SerializeObject(Token);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage response = await cliente.PutAsync($"http://138.197.221.203/api/v1/clients/{idclient.Text}", content);
            string result = response.Content.ReadAsStringAsync().Result;
            Response responseData = JsonConvert.DeserializeObject<Response>(result);
            if (response.IsSuccessStatusCode)
            {                
                App.Current.MainPage = new requireentryphoto();
            }
            else
            {
                
                await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
                App.Current.MainPage = new CargarClientes();

            }          


    }

        private void Picketipocliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picketipocliente.SelectedIndex == 0)
            {
                typeclient.Text = "/api/v1/types/1";
                btna.IsVisible = true;
            }
            else if (picketipocliente.SelectedIndex == 1)
            {
                typeclient.Text = "/api/v1/types/2";
                btna.IsVisible = true;
            }
            else if (picketipocliente.SelectedIndex == 2)
            {
                typeclient.Text = "/api/v1/types/2";
                btna.IsVisible = true;
            }
            btna.IsVisible = true;


        }
        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
    }
}