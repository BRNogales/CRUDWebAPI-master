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
    public partial class incidencias : ContentPage
    {
        public incidencias()
        {
            InitializeComponent();
            OnBackButtonPressed();
            pickeraud.SelectedIndexChanged += Pickeraud_SelectedIndexChanged;
            pck.SelectedIndexChanged += Pck_SelectedIndexChanged;
            btnfinauditoria.Clicked += Btnfinauditoria_Clicked;
        }


        private async void Btnfinauditoria_Clicked(object sender, EventArgs e)
        {
            try
            {
                string idaudit = Application.Current.Properties["idaudit"].ToString();
                if (pickeraud.SelectedIndex == 0)
                {
                    btnfinauditoria.IsEnabled = false;
                    incidenceaudit incidenceau = new incidenceaudit();
                    incidenceau.incidence = "/api/v1/incidences/" + selectincidence.Text;
                    incidenceau.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                    incidenceau.commentaries = coments.Text;
                    HttpClient cliente = new HttpClient();
                    var Token = Settings.token;
                    var json = JsonConvert.SerializeObject(incidenceau);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var token = JsonConvert.SerializeObject(Token);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    HttpResponseMessage response = await cliente.PostAsync("http://138.197.221.203/api/v1/audit_incidences", content);
                    incidenceaudit inc = new incidenceaudit();
                    inc.audited = true;
                    HttpClient cl = new HttpClient();
                    var jp = JsonConvert.SerializeObject(inc);
                    StringContent cn = new StringContent(jp, Encoding.UTF8, "application/json");
                    cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    HttpResponseMessage rp = await cliente.PutAsync($"http://138.197.221.203/api/v1/audits/{idaudit}", cn);
                    string result = response.Content.ReadAsStringAsync().Result;                    
                    Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (response.IsSuccessStatusCode)
                    {
                        App.Current.MainPage = new CargarClientes();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
                        App.Current.MainPage = new incidencias();

                    }
                }
                else
                {
                    btnfinauditoria.IsEnabled = false;
                    incidenceaudit incidenceau = new incidenceaudit();
                    incidenceau.audited = true;
                    HttpClient cliente = new HttpClient();
                    var Token = Settings.token;
                    var json = JsonConvert.SerializeObject(incidenceau);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var token = JsonConvert.SerializeObject(Token);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    HttpResponseMessage response = await cliente.PutAsync($"http://138.197.221.203/api/v1/audits/{idaudit}", content);
                    string result = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        App.Current.MainPage = new CargarClientes();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
                        App.Current.MainPage = new incidencias();

                    }
                }
            }
            catch (Exception)
            {
                btnfinauditoria.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "Se perdio la conexion, Intente de nuevo!", "OK");
               
            }

            
               
        }

        private void Pck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pck.SelectedIndex == 0)
            {
                selectincidence.Text = "1";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 1)
            {
                selectincidence.Text = "2";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 2)
            {
                selectincidence.Text = "3";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 3)
            {
                selectincidence.Text = "4";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 4)
            {
                selectincidence.Text = "5";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 5)
            {
                selectincidence.Text = "6";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 6)
            {
                selectincidence.Text = "7";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 7)
            {
                selectincidence.Text = "8";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 8)
            {
                selectincidence.Text = "9";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 9)
            {
                selectincidence.Text = "10";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 10)
            {
                selectincidence.Text = "11";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 11)
            {
                selectincidence.Text = "12";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 12)
            {
                selectincidence.Text = "13";
                btnfinauditoria.IsVisible = true;
            }
            else if (pck.SelectedIndex == 13)
            {
                selectincidence.Text = "14";
                btnfinauditoria.IsVisible = true;

            }
            else if (pck.SelectedIndex == 14)
            {
                selectincidence.Text = "15";
                btnfinauditoria.IsVisible = true;
            }
            else
            {
                btnfinauditoria.IsVisible = true;
            }
        }

        private void Pickeraud_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pickeraud.SelectedItem.ToString() == "SI")
                {
                    BLL.IsEnabled = true;
                    pck.IsEnabled = true;
                    btnfinauditoria.IsVisible = false;
                    coments.IsEnabled = true;
                }
                else if (pickeraud.SelectedItem.ToString() == "NO")
                {
                    BLL.IsEnabled = false;
                    pck.IsEnabled = false;
                    pck.SelectedItem = null;
                    btnfinauditoria.IsVisible = true;
                    coments.IsEnabled = false;
                }

            }
            catch (Exception)
            {

                DisplayAlert("Alerta!", "Opss! algo ocurrio mal", "Aceptar");
            }
        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
    }
}