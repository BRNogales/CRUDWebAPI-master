
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class photosenfriador : ContentPage
    {
        public MediaFile _mediaFile;
        public photosenfriador()
        {
            InitializeComponent();
            btnimagenenfriador.Clicked += Btnimagenenfriador_Clicked;
            terminado.Clicked += Terminado_Clicked;
            btnimagenenfriador2.Clicked += Btnimagenenfriador2_Clicked;
            btnimagenenfriador3.Clicked += Btnimagenenfriador3_Clicked;
            terminado2.Clicked += Terminado2_Clicked;
            terminado3.Clicked += Terminado3_Clicked;
            finalizar.Clicked += Finalizar_Clicked;
            btnvolver.Clicked += Btnvolver_Clicked;
            
          
            OnBackButtonPressed();
        }

        private void Btnvolver_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new addfrentesandbotles();
        }

        private void Finalizar_Clicked(object sender, EventArgs e)
        {
            finalizar.IsEnabled = false;
            App.Current.MainPage = new enfriadorfin();
        }

        private void Terminado3_Clicked(object sender, EventArgs e)
        {
            try
            {
                terminado3.IsEnabled = false;
                terminado3.IsVisible = false;
                string id = Application.Current.Properties["uuidcoleraudit"].ToString();
                var client = new RestClient($"http://138.197.221.203/api/v1/cooler_audits/{id}/position_picture");
                var request = new RestRequest(Method.POST);
                var Token = Settings.token;
                request.AddHeader("Authorization", "Bearer " + Token);
                request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
                request.AddFile("positionPicture", localpathimg1.Text);
                request.AlwaysMultipartFormData = true;
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    pbar.ProgressTo(1, 300, Easing.Linear);
                    localpathimg1.Text = null;
                    btnimagenenfriador.IsEnabled = false;
                    btnimagenenfriador2.IsEnabled = false;
                    btnimagenenfriador3.IsEnabled = false;
                    finalizar.IsVisible = true;
                    DisplayAlert("Correcto!", "Imagen Subida!", "OK");
                    
                }
                else
                {
                    DisplayAlert("Error!", "Imagen no subida!", "OK");
                    App.Current.MainPage = new photosenfriador();
                }
            }
            catch (Exception)
            {

                DisplayAlert("Oops!", "Algo ocurrio mal!", "OK");
                App.Current.MainPage = new photosenfriador();
            }
        }

        private void Terminado2_Clicked(object sender, EventArgs e)
        {
            try
            {
                terminado2.IsEnabled = false;
                terminado2.IsVisible = false;
                string id = Application.Current.Properties["uuidcoleraudit"].ToString(); 
                var client = new RestClient($"http://138.197.221.203/api/v1/cooler_audits/{id}/fronts_picture");
                var request = new RestRequest(Method.POST);
                var Token = Settings.token;
                request.AddHeader("Authorization", "Bearer " + Token);
                request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
                request.AddFile("frontsPicture", localpathimg1.Text);
                request.AlwaysMultipartFormData = true;
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    pbar.ProgressTo(1, 300, Easing.Linear);
                    localpathimg1.Text = null;
                    btnimagenenfriador3.IsEnabled = true;
                    DisplayAlert("Correcto!", "Imagen Subida!", "OK");
                    
                }
                else
                {
                    DisplayAlert("Error!", "Imagen no subida!", "OK");
                    App.Current.MainPage = new photosenfriador();
                }
            }
            catch (Exception)
            {

                DisplayAlert("Oops!", "Algo ocurrio mal!", "OK");
                App.Current.MainPage = new photosenfriador();
            }
        }

        private async void Btnimagenenfriador3_Clicked(object sender, EventArgs e)
        {
            try
            {
                await pbar.ProgressTo(0, 0, Easing.Linear);
                btnimagenenfriador3.IsEnabled = false;
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
                terminado3.IsVisible = true;
            }
            catch (Exception)
            {

                await DisplayAlert("Oops!", "Algo ocurrio mal!", "OK");
                btnimagenenfriador3.IsEnabled = true;
            }
        }

        private async void Btnimagenenfriador2_Clicked(object sender, EventArgs e)
        {
            try
            {
                await pbar.ProgressTo(0, 0, Easing.Linear);
                btnimagenenfriador2.IsEnabled = false;
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
                terminado2.IsVisible = true;
            }
            catch (Exception)
            {

                await DisplayAlert("Oops!", "Algo ocurrio mal!", "OK");
                btnimagenenfriador2.IsEnabled = true;
            }

        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
        private  void Terminado_Clicked(object sender, EventArgs e)
        {          
            try
            {
                
                terminado.IsEnabled = false;
                terminado.IsVisible = false;
                string id = Application.Current.Properties["uuidcoleraudit"].ToString();
                var client = new RestClient($"http://138.197.221.203/api/v1/cooler_audits/{id}/cooler_picture");
                var request = new RestRequest(Method.POST);
                var Token = Settings.token;
                request.AddHeader("Authorization", "Bearer " + Token);
                request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
                request.AddFile("coolerPicture", localpathimg1.Text);
                request.AlwaysMultipartFormData = true;
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {                  
                    pbar.ProgressTo(1, 300, Easing.Linear);
                    localpathimg1.Text = null;
                    btnimagenenfriador2.IsEnabled = true;
                    DisplayAlert("Correcto!", "Imagen Subida!", "OK");
                   

                }
                else
                {
                    DisplayAlert("Error!", "Imagen no subida!", "OK");
                    App.Current.MainPage = new photosenfriador();
                }
            }
            catch (Exception)
            {

                DisplayAlert("Oops!", "Algo ocurrio mal!", "OK");
                App.Current.MainPage = new photosenfriador();
            }
           
        }

        private async void Btnimagenenfriador_Clicked(object sender, EventArgs e)
        {
            try
            {
                btnimagenenfriador.IsEnabled = false;
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
                terminado.IsVisible = true;
            }
            catch (Exception)
            {

                await DisplayAlert("Oops!", "Algo ocurrio mal!", "OK");
                btnimagenenfriador.IsEnabled = true;
                
            }
            

        }
    }
}