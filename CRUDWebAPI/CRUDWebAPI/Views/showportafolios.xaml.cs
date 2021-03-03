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
    public partial class showportafolios : ContentPage
    {
        public showportafolios()
        {
            InitializeComponent();
            pickertipoportafolio.SelectedIndexChanged += Pickertipoportafolio_SelectedIndexChanged;
            btnvolver.Clicked += Btnvolver_Clicked;
        }

        private void Btnvolver_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new plat1();
        }

        private void Pickertipoportafolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickertipoportafolio.SelectedIndex == 0)
            {
                genricimage.Source = ImageSource.FromResource("CRUDWebAPI.img.comidas.png");
                genricimage2.Source = ImageSource.FromResource("CRUDWebAPI.img.comidasrack.PNG");
                genricimage2.IsVisible = true;
                genricimage.IsVisible = true;
            }
            else if (pickertipoportafolio.SelectedIndex == 1)
            {
                genricimage.Source = ImageSource.FromResource("CRUDWebAPI.img.hidratacion.PNG");
                genricimage2.Source = ImageSource.FromResource("CRUDWebAPI.img.hidratacionrack.PNG");
                genricimage2.IsVisible = true;
                genricimage.IsVisible = true;
            }
            else if (pickertipoportafolio.SelectedIndex == 2)
            {
                genricimage.Source = ImageSource.FromResource("CRUDWebAPI.img.nutricion.PNG");
                genricimage2.Source = ImageSource.FromResource("CRUDWebAPI.img.nutricionrack.PNG");
                genricimage2.IsVisible = true;
                genricimage.IsVisible = true;
            }
            else if (pickertipoportafolio.SelectedIndex == 3)
            {
                genricimage.Source = ImageSource.FromResource("CRUDWebAPI.img.frutales.PNG");
                genricimage2.Source = ImageSource.FromResource("CRUDWebAPI.img.frutalesrack.PNG");
                genricimage2.IsVisible = true;
                genricimage.IsVisible = true;
            }
            else if (pickertipoportafolio.SelectedIndex == 4)
            {
                genricimage.Source = ImageSource.FromResource("CRUDWebAPI.img.energia.PNG");
                genricimage2.Source = ImageSource.FromResource("CRUDWebAPI.img.energiarack.PNG");
                genricimage2.IsVisible = true;
                genricimage.IsVisible = true;
            }
        }
    }
}