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
    public partial class RegistrarEnf : ContentPage
    {
        public RegistrarEnf()
        {
            InitializeComponent();
            pickertipoenf.SelectedIndexChanged += Pickertipoenf_SelectedIndexChanged;
            pickernopuertasenf.SelectedIndexChanged += Pickernopuertasenf_SelectedIndexChanged;
            btnget.Command.Execute(null);
            if (Application.Current.Properties.ContainsKey("idcliente"))
            {
                no_cliente.Text = "/api/v1/clients/" + Application.Current.Properties["idcliente"].ToString();
            }
            btnsiguiente4.Clicked += Btnsiguiente4_Clicked;
            volver.Clicked += Volver_Clicked;
            OnBackButtonPressed();
        }
        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
        private void Volver_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Enf1();
        }

        private void Btnsiguiente4_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new RegistrarEnf();
        }

        private void Pickernopuertasenf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickernopuertasenf.SelectedIndex == 0)
            {
                doors.Text = "1";
                btnsiguiente4.IsVisible = true;
            }
            else if (pickernopuertasenf.SelectedIndex == 1)
            {
                doors.Text = "2";
                btnsiguiente4.IsVisible = true;
            }
            else if (pickernopuertasenf.SelectedIndex == 2)
            {
                doors.Text = "3";
                btnsiguiente4.IsVisible = true;

            }

            else if (pickernopuertasenf.SelectedIndex == 3)
            {
                doors.Text = "4";
                btnsiguiente4.IsVisible = true;

            }
        }

        private void Pickertipoenf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickertipoenf.SelectedIndex == 0)
            {
                type.Text = "/api/v1/types/3";
                lblno.IsEnabled = true;
                pickernopuertasenf.IsEnabled = true;
            }
            else if (pickertipoenf.SelectedIndex == 1)
            {
                type.Text = "/api/v1/types/4";
                lblno.IsEnabled = true;
                pickernopuertasenf.IsEnabled = true;
            }
            else if (pickertipoenf.SelectedIndex == 2)
            {
                type.Text = "/api/v1/types/5";
                lblno.IsEnabled = true;
                pickernopuertasenf.IsEnabled = true;
            }
            else if (pickertipoenf.SelectedIndex == 3)
            {
                type.Text = "/api/v1/types/6";
                lblno.IsEnabled = true;
                pickernopuertasenf.IsEnabled = true;
            }
        }
    }
}