using CRUDWebAPI.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Media;
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
    public partial class Comunicacion : ContentPage
    {
        public Comunicacion()
        {
            InitializeComponent();
            btnshowpop.Clicked += Btnshowpop_Clicked; btncerrarc.Clicked += Btncerrarc_Clicked;
            volver.Clicked += Volver_Clicked;
            btnshowpop.Clicked += Btnshowpop_Clicked1;
            apear();
            btnadddinamic.Clicked += Btnadddinamic_Clicked;

            pickertipodinamic.SelectedIndexChanged += Pickertipodinamic_SelectedIndexChanged;
            pickertipoestruct.SelectedIndexChanged += Pickertipoestruct_SelectedIndexChanged;
            btnadd.Clicked += Btnadd_Clicked;
            btnsiguiente4.Clicked += Btnsiguiente4_Clicked;
            btnaddimage.Clicked += Btnaddimage_Clicked;
            pckcantidad.SelectedIndexChanged += Pckcantidad_SelectedIndexChanged;
            pickertipodinamic.SelectedIndexChanged += Pickertipodinamic_SelectedIndexChanged1;
            pckcantidaddinamic.SelectedIndexChanged += Pckcantidaddinamic_SelectedIndexChanged;

        }

        private void Pckcantidaddinamic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pckcantidaddinamic.SelectedItem != null)
            {
                btnadddinamic.IsEnabled = true;
            }
            else
            {
                btnadddinamic.IsEnabled = false;
            }
        }

        private void Pickertipodinamic_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (pickertipodinamic.SelectedItem != null)
            {
                btnadddinamic.IsEnabled = false;
            }
            else
            {
                return;
            }
        }

        private void Pckcantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pckcantidad.SelectedItem != null)
            {
                btnadd.IsEnabled = true;
            }
            else
            {
                return;
            }
        }

        private void Btnaddimage_Clicked(object sender, EventArgs e)
        {
            try
            {
                btnaddimage.IsVisible = false;
                UploadImages upload = new UploadImages();
                var response = upload.uploadimadinamic(localpathimg1);
                if (response.IsSuccessful)
                {
                    localpathimg1.Text = null;
                    btnadddinamic.IsVisible = true;
                    DisplayAlert("Correcto", "Se agrego material dinamico correctamente!", "OK");
                    pickertipodinamic.IsEnabled = true;
                    pickertipoestruct.IsEnabled = true;
                    sipop1.IsEnabled = true;
                    sipop2.IsEnabled = true;
                    sipop3.IsEnabled = true;
                    pckcantidad.IsEnabled = true;
                    pckcantidaddinamic.IsEnabled = true;
                    btnshowpop.IsEnabled = true;
                    btnadd.IsEnabled = true;
                }
                else
                {
                    DisplayAlert("Error!", "No se agrego material dinamico!", "OK");
                    App.Current.MainPage = new Comunicacion();
                }
            }
            catch (Exception)
            {

                DisplayAlert("Oops!", "Algo ocurrio mal!", "OK");
                App.Current.MainPage = new Comunicacion();
            }


        }

        private void Btnsiguiente4_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new seleccionarcriterioaEv();
        }

        private void Btnadd_Clicked(object sender, EventArgs e)
        {
            addstructural();
            lbltype.Text = null;
            pickertipoestruct.SelectedItem = null;
            pckcantidad.SelectedItem = null;
        }

        private void Pickertipoestruct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pickertipoestruct.SelectedIndex == 0)
                {
                    lbltype.Text = "/api/v1/types/25";
                }
                else if (pickertipoestruct.SelectedIndex == 1)
                {
                    lbltype.Text = "/api/v1/types/26";
                }
                else if (pickertipoestruct.SelectedIndex == 2)
                {
                    lbltype.Text = "/api/v1/types/27";
                }
                else if (pickertipoestruct.SelectedIndex == 3)
                {
                    lbltype.Text = "/api/v1/types/28";
                }
                else if (pickertipoestruct.SelectedIndex == 4)
                {
                    lbltype.Text = "/api/v1/types/29";
                }
                else if (pickertipoestruct.SelectedIndex == 5)
                {
                    lbltype.Text = "/api/v1/types/30";
                }
                else if (pickertipoestruct.SelectedIndex == 6)
                {
                    lbltype.Text = "/api/v1/types/31";
                }
                else
                {
                    return;
                }

            }
            catch (Exception)
            {

                Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
            }


        }

        private void Btnadddinamic_Clicked(object sender, EventArgs e)
        {
            addinamic();
            pickertipodinamic.SelectedItem = null;
            pckcantidaddinamic.SelectedItem = null;
            sipop1.Checked = false;
            sipop2.Checked = false;
            sipop3.Checked = false;
            lbltype.Text = null;
        }

        private void Pickertipodinamic_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pickertipodinamic.SelectedIndex == 0)
                {
                    lbltype.Text = "/api/v1/types/18";
                    sipop1.IsVisible = true;
                    sipop2.IsVisible = true;
                    sipop3.IsVisible = true;
                    lblpop1.IsVisible = true;
                    lblpop2.IsVisible = true;
                    lblpop3.IsVisible = true;

                }
                else if (pickertipodinamic.SelectedIndex == 1)
                {
                    lbltype.Text = "/api/v1/types/19";
                    sipop1.IsVisible = true;
                    sipop2.IsVisible = true;
                    sipop3.IsVisible = true;
                    lblpop1.IsVisible = true;
                    lblpop2.IsVisible = true;
                    lblpop3.IsVisible = true;
                }
                else if (pickertipodinamic.SelectedIndex == 2)
                {
                    lbltype.Text = "/api/v1/types/20";
                    sipop1.IsVisible = false;
                    sipop2.IsVisible = false;
                    sipop3.IsVisible = false;
                    lblpop1.IsVisible = false;
                    lblpop2.IsVisible = false;
                    lblpop3.IsVisible = false;
                }
                else if (pickertipodinamic.SelectedIndex == 3)
                {
                    lbltype.Text = "/api/v1/types/21";
                    sipop1.IsVisible = false;
                    sipop2.IsVisible = false;
                    sipop3.IsVisible = false;
                    lblpop1.IsVisible = false;
                    lblpop2.IsVisible = false;
                    lblpop3.IsVisible = false;
                }
                else if (pickertipodinamic.SelectedIndex == 4)
                {
                    lbltype.Text = "/api/v1/types/22";
                    sipop1.IsVisible = false;
                    sipop2.IsVisible = false;
                    sipop3.IsVisible = false;
                    lblpop1.IsVisible = false;
                    lblpop2.IsVisible = false;
                    lblpop3.IsVisible = false;
                }
                else if (pickertipodinamic.SelectedIndex == 5)
                {
                    lbltype.Text = "/api/v1/types/23";
                    sipop1.IsVisible = false;
                    sipop2.IsVisible = false;
                    sipop3.IsVisible = false;
                    lblpop1.IsVisible = false;
                    lblpop2.IsVisible = false;
                    lblpop3.IsVisible = false;
                }
                else if (pickertipodinamic.SelectedIndex == 6)
                {
                    lbltype.Text = "/api/v1/types/24";
                    sipop1.IsVisible = false;
                    sipop2.IsVisible = false;
                    sipop3.IsVisible = false;
                    lblpop1.IsVisible = false;
                    lblpop2.IsVisible = false;
                    lblpop3.IsVisible = false;
                }
                else
                {
                    return;
                }

            }
            catch (Exception)
            {

                Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
            }
            
        }

        private void apear()
        {
            try
            {
                string token = Settings.token;
                coolers Lcoolers = new coolers();
                List<typlatfom> matstruct = Lcoolers.getstructural(token);
                pickertipoestruct.ItemsSource = matstruct;
                List<typlatfom> matdinamic = Lcoolers.getdinamic(token);
                pickertipodinamic.ItemsSource = matdinamic;

            }
            catch (Exception)
            {

                Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
            }
            
        }
        private void Btnshowpop_Clicked1(object sender, EventArgs e)
        {
            App.Current.MainPage = new requiredphotos();
        }

        private async void addinamic()
        {
            try
            {
                DynamicCommunication _dynamic = new DynamicCommunication();
                _dynamic.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                _dynamic.compliesPop1 = sipop1.Checked;
                _dynamic.compliesPop2 = sipop2.Checked;
                _dynamic.compliesPop3 = sipop3.Checked;
                _dynamic.quantity = Convert.ToInt32(pckcantidaddinamic.SelectedItem);
                _dynamic.dynamicType = lbltype.Text;

                HttpClient cliente = new HttpClient();
                var Token = Settings.token;
                var json = JsonConvert.SerializeObject(_dynamic);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var token = JsonConvert.SerializeObject(Token);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                HttpResponseMessage response = await cliente.PostAsync("http://138.197.221.203/api/v1/dynamic_communications", content);
                string result = response.Content.ReadAsStringAsync().Result;
                JObject rss = JObject.Parse(result);
                string rssTitle = (string)rss["id"];
                Application.Current.Properties["uuiddinamic"] = rssTitle;
                Response responseData = JsonConvert.DeserializeObject<Response>(result);
                if (response.IsSuccessStatusCode)
                {
                    takephoto();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se agrego el material dinamico!", "OK");
                }

            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
            }
                 
        }

        private async void takephoto()
        {
            try
            {
                pickertipodinamic.IsEnabled = false;
                pickertipoestruct.IsEnabled = false;
                sipop1.IsEnabled = false;
                sipop2.IsEnabled = false;
                btnadd.IsEnabled = false;
                sipop3.IsEnabled = false;
                pckcantidad.IsEnabled = false;
                pckcantidaddinamic.IsEnabled = false;
                btnshowpop.IsEnabled = false;
                btnadddinamic.IsVisible = false;
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {

                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                localpathimg1.Text = file.Path;
                btnaddimage.IsVisible = true;
            }
            catch (Exception)
            {

                await DisplayAlert("Oops!", "Algo ocurrio mal!", "OK");
                btnadddinamic.IsVisible = true;
                pickertipodinamic.IsEnabled = true;
                pickertipoestruct.IsEnabled = true;
                sipop1.IsEnabled = true;
                sipop2.IsEnabled = true;
                sipop3.IsEnabled = true;
                pckcantidad.IsEnabled = true;
                pckcantidaddinamic.IsEnabled = true;
                btnshowpop.IsEnabled = true;
                btnadd.IsEnabled = true;
            }


        }

        private async void addstructural()
        {
            try
            {
                addstructural _addstructural = new addstructural();
                _addstructural.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                _addstructural.quantity = Convert.ToInt32(pckcantidad.SelectedItem);
                _addstructural.structuralType = lbltype.Text;

                HttpClient cliente = new HttpClient();
                var Token = Settings.token;
                var json = JsonConvert.SerializeObject(_addstructural);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var token = JsonConvert.SerializeObject(Token);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                HttpResponseMessage response = await cliente.PostAsync("http://138.197.221.203/api/v1/structural_communications", content);
                string result = response.Content.ReadAsStringAsync().Result;
                Response responseData = JsonConvert.DeserializeObject<Response>(result);
                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Correcto", "Se agrego material estructural correctamente!", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se agrego el material estructural!", "OK");
                }

            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
            }

        }

        private void Volver_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new seleccionarcriterioaEv();
        }

        private async void Btncerrarc_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ans = await DisplayAlert("Info!", "¿Deseas cerrar sesion o abortar auditoria?", "Cerrar Sesion", "Abortar");
                if (ans == true)
                {
                    var tr = await DisplayAlert("Alerta!", "¿Realmente quieres cerrar sesion?", "Aceptar", "Cancelar");
                    if (tr == true)
                    {
                        App.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    var fl = await DisplayAlert("Alerta!", "¿Realmente quieres abortar la auditoria?", "Aceptar", "Cancelar");
                    if (fl == true)
                    {
                        App.Current.MainPage = new incidencias();
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception)
            {

                await DisplayAlert("Alerta!", "Opss! algo ocurrio mal", "Aceptar");
            }
        }

        private void Btnshowpop_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}