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
    public partial class requireentryphoto : ContentPage
    {
        public requireentryphoto()
        {
            InitializeComponent();
            btnimagentipocliente.Clicked += Btnimagentipocliente_Clicked;
            terminado.Clicked += Terminado_Clicked;
            finalizar.Clicked += Finalizar_Clicked;
        }

        private void Finalizar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new seleccionarcriterioaEv();
        }

        private void Terminado_Clicked(object sender, EventArgs e)
        {
            try
            {

                terminado.IsEnabled = false;
                terminado.IsVisible = false;
                UploadImages upload = new UploadImages();
                var response = upload.uploadimaenty(localpathimg1);
                if (response.IsSuccessful)
                {
                    localpathimg1.Text = null;
                    finalizar.IsVisible = true;
                    DisplayAlert("Correcto!", "Imagen Subida!", "OK");


                }
                else
                {
                    DisplayAlert("Error!", "Imagen no subida!", "OK");
                    App.Current.MainPage = new requireentryphoto();
                }
            }
            catch (Exception)
            {

                DisplayAlert("Oops!", "Algo ocurrio mal!", "OK");
                App.Current.MainPage = new requireentryphoto();
            }
        }

        private async void Btnimagentipocliente_Clicked(object sender, EventArgs e)
        {
            try
            {
                btnimagentipocliente.IsEnabled = false;
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
                btnimagentipocliente.IsEnabled = true;
            }

        }
    }
}