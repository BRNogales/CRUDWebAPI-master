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
    public partial class requiredphotos : ContentPage
    {
        public requiredphotos()
        {
            InitializeComponent();
            btnvolver.Clicked += Btnvolver_Clicked;
            imgstilss.Source = ImageSource.FromResource("CRUDWebAPI.img.febrero.jpeg");
        }

        private void Btnvolver_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Comunicacion();
        }
    }
}