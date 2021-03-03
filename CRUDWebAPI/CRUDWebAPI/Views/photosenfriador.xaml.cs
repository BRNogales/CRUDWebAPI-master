
using CRUDWebAPI.Clases;
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
            btncerrarc.Clicked += Btncerrarc_Clicked;
            
          
            OnBackButtonPressed();
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

        private async void Btnvolver_Clicked(object sender, EventArgs e)
        {
            try
            {
                var tr = await DisplayAlert("Alerta!", "¿Realmente quieres Volver?", "Aceptar", "Cancelar");
                if (tr == true)
                {
                    App.Current.MainPage = new addfrentesandbotles();
                }
                else
                {
                    return;
                }

            }
            catch (Exception)
            {

                await DisplayAlert("Oops!", "Parece que algo ocurrio mal!", "Aceptar");
            }          
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
                UploadImages upload = new UploadImages();
                var response = upload.uploadposition(localpathimg1);
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
                UploadImages upload = new UploadImages();
                var response = upload.uploadfrontspicture(localpathimg1);
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
                UploadImages upload = new UploadImages();
                var response = upload.uploadcoolerpicture(localpathimg1);
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