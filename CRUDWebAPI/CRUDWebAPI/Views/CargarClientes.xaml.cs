using CRUDWebAPI.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace CRUDWebAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CargarClientes : ContentPage
    {
        public CargarClientes()
        {
            InitializeComponent();
            btnget.Command.Execute(null);
            OnBackButtonPressed();
            btnac.Clicked += Btnac_Clicked;     
        }

    

        private void Btnac_Clicked(object sender, EventArgs e)
        {
            btnget.Command.Execute(null);
        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            try
            {
                var dataItem = e.Item as RutasdeAuditores;
                App.Current.MainPage = new DetailClient(dataItem.client.name, dataItem.client.tradename,dataItem.client.route.routeNumber, dataItem.client.id, dataItem.id);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta!", ex.ToString(), "Aceptar");
            }

        }
    }
}
