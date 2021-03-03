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
    public partial class enfriadorfin : ContentPage
    {
        public enfriadorfin()
        {
            InitializeComponent();
            btnaevaluar.Clicked += Btnaevaluar_Clicked;
            btnfinenfriador.Clicked += Btnfinenfriador_Clicked;
            OnBackButtonPressed();
            btncerrarc.Clicked += Btncerrarc_Clicked;
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
        private void Btnfinenfriador_Clicked(object sender, EventArgs e)
        {
            btnfinenfriador.IsEnabled = false;
            App.Current.MainPage = new seleccionarcriterioaEv();
        }

        private void Btnaevaluar_Clicked(object sender, EventArgs e)
        {
            btnaevaluar.IsEnabled = false;
            App.Current.MainPage = new Enf1();
        }
    }
}