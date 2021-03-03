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
    public partial class Enf2 : ContentPage
    {
        public Enf2()
        {
            InitializeComponent();
            OnBackButtonPressed();
        }
        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
    }
}