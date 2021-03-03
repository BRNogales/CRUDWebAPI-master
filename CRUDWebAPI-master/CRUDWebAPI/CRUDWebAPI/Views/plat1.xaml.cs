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
    public partial class plat1 : ContentPage
    {
        public plat1()
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