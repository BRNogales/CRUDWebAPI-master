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
    public partial class seleccionarcriterioaEv : ContentPage
    {
        public seleccionarcriterioaEv()
        {
            InitializeComponent();
            imgdetail.Source = ImageSource.FromResource("CRUDWebAPI.img.botlecoca.png");
            btncalifenfriador.Clicked += Btncalifenfriador_Clicked;
            OnBackButtonPressed();
            btncerrarc.Clicked += Btncerrarc_Clicked;
            btnfins.Clicked += Btnfins_Clicked;
            btncalifPlataformas.Clicked += BtncalifPlataformas_Clicked;
            btncalifcomunicacion.Clicked += Btncalifcomunicacion_Clicked;
            typeclienteval();
        }

        private void typeclienteval()
        {
            lblyupeclient.Text = Application.Current.Properties["typeclientevaluation"].ToString();
            if (lblyupeclient.Text == "Enrejado")
            {
                btncalifPlataformas.IsEnabled = false;
            }
            else
            {
                return;
            }
        }

        private void Btncalifcomunicacion_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Comunicacion();
        }

        private void BtncalifPlataformas_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new plat1();
        }

        private async void Btnfins_Clicked(object sender, EventArgs e)
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

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
        private void Btncalifenfriador_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Enf1();
        }
    }
}