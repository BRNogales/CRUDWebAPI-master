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