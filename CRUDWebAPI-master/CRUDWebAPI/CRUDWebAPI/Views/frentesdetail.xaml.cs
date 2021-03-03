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
    public partial class frentesdetail : ContentPage
    {
        public frentesdetail(int code, string description, string brandname, string feavorname, string packagetype, string presentationsize, string id )
        {
            InitializeComponent();
            imgaddprod.Source = ImageSource.FromResource("CRUDWebAPI.img.productadd.png");
            cod_product.Text = code.ToString();
            desc_product.Text = description;
            brand.Text = brandname;
            flavor.Text = feavorname;
            package.Text = packagetype;
            presentacion.Text = presentationsize;
            uuidc.Text = id;
            pickernobotellas.SelectedIndexChanged += Pickernobotellas_SelectedIndexChanged;
            pickernofrentes.SelectedIndexChanged += Pickernofrentes_SelectedIndexChanged;
            btnagg.Clicked += Btnagg_Clicked;
            OnBackButtonPressed();
            volver.Clicked += Volver_Clicked;
        }

        private void Volver_Clicked(object sender, EventArgs e)
        {
            volver.IsEnabled = false;
            App.Current.MainPage = new addfrentesandbotles();
        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
        private async void Btnagg_Clicked(object sender, EventArgs e)
        { 
                btnagg.IsEnabled = false;
                products addfrentes = new products();
                addfrentes.cooler = "/api/v1/coolers/" + Application.Current.Properties["uuidcooler"].ToString();
                addfrentes.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                addfrentes.product = "/api/v1/products/" + uuidc.Text;
                addfrentes.quantity = Convert.ToInt32(pickernofrentes.SelectedItem);
                addfrentes.singleBottles = Convert.ToInt32(pickernobotellas.SelectedItem);
                HttpClient cliente = new HttpClient();
                var Token = Settings.token;
                var json = JsonConvert.SerializeObject(addfrentes);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var token = JsonConvert.SerializeObject(Token);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                HttpResponseMessage response = await cliente.PostAsync("http://138.197.221.203/api/v1/fronts", content);
                string result = response.Content.ReadAsStringAsync().Result;
                Response responseData = JsonConvert.DeserializeObject<Response>(result);

            if (response.IsSuccessStatusCode)
            {
                App.Current.MainPage = new addfrentesandbotles();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
                App.Current.MainPage = new addfrentesandbotles();
            }
        }

        private void Pickernofrentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickernofrentes.SelectedItem != null)
            {
                btnagg.IsVisible = true;
            }
            else
            {
                btnagg.IsVisible = false;
            }
        }

        private void Pickernobotellas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickernobotellas.SelectedItem != null)
            {
                pickernofrentes.IsEnabled = true;
            }
            else
            {
                pickernofrentes.IsEnabled = false;
            }
        }
    }
}