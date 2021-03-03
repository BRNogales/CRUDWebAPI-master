using CRUDWebAPI.Clases;
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
            volver.Clicked += Volver_Clicked;
            btncerrarc.Clicked += Btncerrarc_Clicked;
            exhibidor.CheckedChanged += Exhibidor_CheckedChanged;
            anaquel.CheckedChanged += Anaquel_CheckedChanged;
            pickertipoplat.SelectedIndexChanged += Pickertipoplat_SelectedIndexChanged;
            btnsiguiente4.Clicked += Btnsiguiente4_Clicked;
            apear();
            btnshowport.Clicked += Btnshowport_Clicked;
            siportafolio.CheckedChanged += Siportafolio_CheckedChanged;


        }

        private void Siportafolio_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if (siportafolio.Checked == true)
            {
                lblfrentes.IsVisible = true;
                txtfrentes.IsVisible = true;
            }
            else if (siportafolio.Checked == false)
            {
                lblfrentes.IsVisible = false;
                txtfrentes.IsVisible = false;
            }
        }

        private void Btnshowport_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new showportafolios();
        }

        private void apear()
        {
            string token = Settings.token;
            coolers Lcoolers = new coolers();
            List<typlatfom> typlatfoms3 = Lcoolers.GetTyplatfoms(token);
            pickertipoplat.ItemsSource = typlatfoms3;           
        }
        private void Btnsiguiente4_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new photosplataformas();
        }

        private void Pickertipoplat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickertipoplat.SelectedItem != null)
            {
                if (pickertipoplat.SelectedIndex == 0)
                {
                    lbltypeplat.Text = "/api/v1/types/11";
                }
                else if (pickertipoplat.SelectedIndex == 1)
                {
                    lbltypeplat.Text = "/api/v1/types/12";
                }
                else if (pickertipoplat.SelectedIndex == 2)
                {
                    lbltypeplat.Text = "/api/v1/types/13";
                }
                else if (pickertipoplat.SelectedIndex == 3)
                {
                    lbltypeplat.Text = "/api/v1/types/14";
                }
                else if (pickertipoplat.SelectedIndex == 4)
                {
                    lbltypeplat.Text = "/api/v1/types/17";
                }
                siportafolio.IsEnabled = true;
                sirespeto.IsEnabled = true;
                sicomunicacion.IsEnabled = true;
                exhibidor.IsEnabled = true;
                anaquel.IsEnabled = true;

            }
            else
            {
                return;
            }
        }

        private void Anaquel_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if (anaquel.Checked == true)
            {
                exhibidor.IsVisible = false;
                btnsiguiente4.IsVisible = true;
                lbltypeexib.Text = "/api/v1/types/16";
            }
            else if (anaquel.Checked == false)
            {
                exhibidor.IsVisible = true;
                btnsiguiente4.IsVisible = false;
            }
        }

        private void Exhibidor_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if (exhibidor.Checked == true)
            {
                anaquel.IsVisible = false;
                btnsiguiente4.IsVisible = true;
                lbltypeexib.Text = "/api/v1/types/15";
            }
            else if (exhibidor.Checked == false)
            {
                anaquel.IsVisible = true;
                btnsiguiente4.IsVisible = false;
            }
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

        private void Volver_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new seleccionarcriterioaEv();
        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }

    }
}