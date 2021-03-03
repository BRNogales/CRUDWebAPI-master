using CRUDWebAPI.Clases;
using CRUDWebAPI.ModelViewsModel;
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
    public partial class Enf1 : ContentPage
    {
        public Enf1()
        {
            
            InitializeComponent();
            btngetc.Command.Execute(null); ;
            pickerllenado.SelectedIndexChanged += Pickerllenado_SelectedIndexChanged;
            btnreg.Clicked += Btnreg_Clicked;
            if (Application.Current.Properties.ContainsKey("idcliente"))
            {
                no_cliente.Text = Application.Current.Properties["idcliente"].ToString();

            }
            btnsiguiente2.Clicked += Btnsiguiente2_Clicked;
            OnBackButtonPressed();
            btnvolver.Clicked += Btnvolver_Clicked;
            btncerrarc.Clicked += Btncerrarc_Clicked;
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

        private void Btnvolver_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new seleccionarcriterioaEv();
        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }
        
        private void Btnsiguiente2_Clicked(object sender, EventArgs e)
        {
            btnsiguiente2.IsEnabled = false;
            Application.Current.Properties["uuidcooler"] = noidenf.Text.ToString();
            
        }

        private void Btnreg_Clicked(object sender, EventArgs e)
        {
            btnreg.IsEnabled = false;
            App.Current.MainPage = new RegistrarEnf();
        }


        private void Pickerllenado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerllenado.Items[pickerllenado.SelectedIndex].ToString() == "Enfriador Coca-Cola")
            {
                if (pickerllenado.SelectedIndex == -1)
                {
                    
                    lblllenado75.IsEnabled = false;
                    sillenado.IsEnabled = false;
                    lblfisrtpos.IsEnabled = false;
                    siprimerapos.IsEnabled = false;
                    siinvaded.IsEnabled = false;
                    lblfisrtpos.IsEnabled = false;
                    btnsiguiente2.IsVisible = false;
                    lblivasiontipo.IsVisible = false;

                }
                else if (pickerllenado.SelectedIndex == 0)
                {

                    pickerid.SelectedIndex = 0;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = true;
                    sillenado.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    siprimerapos.IsVisible = true;
                    siinvaded.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    lblllenado75.IsEnabled = true;
                    sillenado.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    siprimerapos.IsEnabled = true;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;

                }
                else if (pickerllenado.SelectedIndex == 1)
                {

                    pickerid.SelectedIndex = 1;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = true;
                    sillenado.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    siprimerapos.IsVisible = true;
                    siinvaded.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    lblllenado75.IsEnabled = true;
                    sillenado.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    siprimerapos.IsEnabled = true;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 2)
                {

                    pickerid.SelectedIndex = 2;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = true;
                    sillenado.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    siprimerapos.IsVisible = true;
                    siinvaded.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    lblllenado75.IsEnabled = true;
                    sillenado.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    siprimerapos.IsEnabled = true;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 3)
                {

                    pickerid.SelectedIndex = 3;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = true;
                    sillenado.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    siprimerapos.IsVisible = true;
                    siinvaded.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    lblllenado75.IsEnabled = true;
                    sillenado.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    siprimerapos.IsEnabled = true;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 4)
                {

                    pickerid.SelectedIndex = 4;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = true;
                    sillenado.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    siprimerapos.IsVisible = true;
                    siinvaded.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    lblllenado75.IsEnabled = true;
                    sillenado.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    siprimerapos.IsEnabled = true;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 5)
                {

                    pickerid.SelectedIndex = 5;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = true;
                    sillenado.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    siprimerapos.IsVisible = true;
                    siinvaded.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    lblllenado75.IsEnabled = true;
                    sillenado.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    siprimerapos.IsEnabled = true;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 6)
                {

                    pickerid.SelectedIndex = 6;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = true;
                    sillenado.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    siprimerapos.IsVisible = true;
                    siinvaded.IsVisible = true;
                    lblfisrtpos.IsVisible = true;
                    lblllenado75.IsEnabled = true;
                    sillenado.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    siprimerapos.IsEnabled = true;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsEnabled = true;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                }

            }
            else if (pickerllenado.Items[pickerllenado.SelectedIndex].ToString() == "Refrigerador del Detallista")
            {
                if (pickerllenado.SelectedIndex == -1)
                {
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                    


                }
                else if (pickerllenado.SelectedIndex == 0)
                {

                    pickerid.SelectedIndex = 0;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = false;
                    lblinvasions.IsVisible = false;
                    lblivasiontipo.IsVisible = false;


                }
                else if (pickerllenado.SelectedIndex == 1)
                {

                    pickerid.SelectedIndex = 1;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                    lblinvasions.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                }
                else if (pickerllenado.SelectedIndex == 2)
                {

                    pickerid.SelectedIndex = 2;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                    lblinvasions.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                }
                else if (pickerllenado.SelectedIndex == 3)
                {

                    pickerid.SelectedIndex = 3;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                    lblinvasions.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                }
                else if (pickerllenado.SelectedIndex == 4)
                {

                    pickerid.SelectedIndex = 4;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                    lblinvasions.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                }
                else if (pickerllenado.SelectedIndex == 5)
                {

                    pickerid.SelectedIndex = 5;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                    lblinvasions.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                }
                else if (pickerllenado.SelectedIndex == 6)
                {

                    pickerid.SelectedIndex = 6;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                    lblinvasions.IsVisible = false;
                    lblivasiontipo.IsVisible = false;
                }
            }
            else if (pickerllenado.Items[pickerllenado.SelectedIndex].ToString() == "Camara Fría")
            {
                if (pickerllenado.SelectedIndex == -1)
                {
                    lblllenado75.IsEnabled = false;
                    sillenado.IsEnabled = false;
                    lblfisrtpos.IsEnabled = false;
                    siprimerapos.IsEnabled = false;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsEnabled = false;
                    btnsiguiente2.IsVisible = false;
                    pickerinvasiontipo.IsVisible = false;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                    siinvaded.IsVisible = true;

                }
                else if (pickerllenado.SelectedIndex == 0)
                {

                    pickerid.SelectedIndex = 0;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                    siinvaded.IsVisible = true;

                }
                else if (pickerllenado.SelectedIndex == 1)
                {

                    pickerid.SelectedIndex = 1;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                    siinvaded.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 2)
                {

                    pickerid.SelectedIndex = 2;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                    siinvaded.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 3)
                {

                    pickerid.SelectedIndex = 3;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                    siinvaded.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 4)
                {

                    pickerid.SelectedIndex = 4;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsEnabled = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                    siinvaded.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 5)
                {

                    pickerid.SelectedIndex = 5;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsEnabled = false;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                    siinvaded.IsVisible = true;
                }
                else if (pickerllenado.SelectedIndex == 6)
                {

                    pickerid.SelectedIndex = 6;
                    noidenf.Text = pickerid.Items[pickerid.SelectedIndex].ToString();
                    lblllenado75.IsVisible = false;
                    sillenado.IsVisible = false;
                    lblfisrtpos.IsVisible = false;
                    siprimerapos.IsVisible = false;
                    siinvaded.IsEnabled = true;
                    lblfisrtpos.IsVisible = false;
                    btnsiguiente2.IsVisible = true;
                    pickerinvasiontipo.IsVisible = true;
                    lblivasiontipo.IsVisible = true;
                    lblinvasions.IsVisible = true;
                    siinvaded.IsVisible = true;
                }
            }
        }

        private void siinvaded_CheckedChanged(object sender, EventArgs e)
        {
            if (siinvaded.Checked == true)
            {
                pickerinvasiontipo.IsEnabled = true;
            }
            else
            {
                pickerinvasiontipo.IsEnabled = false;
                pickerinvasiontipo.SelectedItem = null;

            }
                

         
        }
    }
}