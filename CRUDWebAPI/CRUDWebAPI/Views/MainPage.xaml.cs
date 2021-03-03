using CRUDWebAPI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUDWebAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Application.Current.Properties["uuidcoleraudit"] = "uuid";
            Application.Current.Properties["uuidplatformsaudit"] = "uuid";
            InitializeComponent();
            imglog.Source = ImageSource.FromResource("CRUDWebAPI.img.img.jpg");
            btniniciarsesion.Clicked += Btniniciarsesion_Clicked;
            OnBackButtonPressed();
        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
        private void Btniniciarsesion_Clicked(object sender, EventArgs e)
        {
            btniniciarsesion.IsEnabled = false;
        }
    }
}
