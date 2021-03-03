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
            btncalifenfriador.Clicked += Btncalifenfriador_Clicked;
            OnBackButtonPressed();
            btnfins.Clicked += Btnfins_Clicked;
        }

        private async void Btnfins_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ans = await DisplayAlert("Alerta!", "¿Realmente quieres terminar la auditoria?" , "Aceptar", "Cancelar");
                if (ans == true)
                {
                    App.Current.MainPage = new incidencias();
                }
                else
                {
                    return;
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