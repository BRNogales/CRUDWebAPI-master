using CRUDWebAPI.Clases;
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
    public partial class addfrentesandbotles : ContentPage
    {
        public addfrentesandbotles()
        {
            try
            {
                InitializeComponent();
                apear();
                buscarc.TextChanged += Buscarc_TextChanged;
                ListView1.ItemSelected += ListView1_ItemSelected;
                btnfinalizarfrentes.Clicked += Btnfinalizarfrentes_Clicked;
                OnBackButtonPressed();
            }
            catch (Exception)
            {

                DisplayAlert("Alerta!", "Opss! algo ocurrio mal", "Aceptar");
            }
        }

        private void Btnfinalizarfrentes_Clicked(object sender, EventArgs e)
        {
            btnfinalizarfrentes.IsEnabled = false;
            App.Current.MainPage = new photosenfriador();
        }

        private async void ListView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var dataItem = e.SelectedItem as products;
                 App.Current.MainPage = new frentesdetail(dataItem.code, dataItem.description, dataItem.brand.name, dataItem.flavor.name, dataItem.package.packType, dataItem.presentation.size, dataItem.id);

            }
            catch (Exception)
            {

                await DisplayAlert("Alerta!", "Opss! algo ocurrio mal", "Aceptar");
            }
        }


        public async void apear()
        {
            string content;
            HttpClient client = new HttpClient();
            var Token = Settings.token;
            var token = JsonConvert.SerializeObject(Token);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            string RestURL = "http://138.197.221.203/api/v1/products?page=1";
            client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(RestURL);
            content = await response.Content.ReadAsStringAsync();
            var Items = JsonConvert.DeserializeObject<List<products>>(content);
            ListView1.ItemsSource = Items;
        }
        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }


        private async void Buscarc_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string content;
                HttpClient client = new HttpClient();
                var Token = Settings.token;
                var token = JsonConvert.SerializeObject(Token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                string RestURL = $"http://138.197.221.203/api/v1/products?code={buscarc.Text}";
                client.BaseAddress = new Uri(RestURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(RestURL);
                content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<products>>(content);
                ListView1.ItemsSource = Items;               
            }
            catch (Exception)
            {

                await DisplayAlert("Alerta!", "Opss! algo ocurrio mal", "Aceptar");
            }
        }
    }
}