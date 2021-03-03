using CRUDWebAPI.Clases;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDWebAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class photosplataformas : ContentPage
    {
        public photosplataformas()
        {
            InitializeComponent();
            btnvolver.Clicked += Btnvolver_Clicked;
            btncerrarc.Clicked += Btncerrarc_Clicked;
            OnBackButtonPressed();
            btnimageplat.Clicked += Btnimageplat_Clicked;
            terminado.Clicked += Terminado_Clicked;
            btnimageplat2.Clicked += Btnimageplat2_Clicked;
            terminado2.Clicked += Terminado2_Clicked;
            finalizar.Clicked += Finalizar_Clicked;
        }

        private void Finalizar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Finplat();
        }

        private void Terminado2_Clicked(object sender, EventArgs e)
        {
            try
            {
                terminado2.IsEnabled = false;
                terminado2.IsVisible = false;
                Uploadimagesplat upload = new Uploadimagesplat();
                var response = upload.uploadplatcost(localpathimg1);
                if (response.IsSuccessful)
                {
                    pbar.ProgressTo(1, 300, Easing.Linear);
                    localpathimg1.Text = null;
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

        private async void Btnimageplat2_Clicked(object sender, EventArgs e)
        {

            try
            {
                await pbar.ProgressTo(0, 0, Easing.Linear);
                btnimageplat2.IsEnabled = false;
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
                btnimageplat2.IsEnabled = true;
            }

        }

        private void Terminado_Clicked(object sender, EventArgs e)
        {
            try
            {

                terminado.IsEnabled = false;
                terminado.IsVisible = false;
                Uploadimagesplat upload = new Uploadimagesplat();
                var response = upload.uploadplatfront(localpathimg1);
                if (response.IsSuccessful)
                {
                    pbar.ProgressTo(1, 300, Easing.Linear);
                    localpathimg1.Text = null;
                    btnimageplat2.IsEnabled = true;
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

        private async void Btnimageplat_Clicked(object sender, EventArgs e)
        {

            try
            {
                btnimageplat.IsEnabled = false;
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
                btnimageplat.IsEnabled = true;

            }
        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
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
                    App.Current.MainPage = new plat1();
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
    }
}