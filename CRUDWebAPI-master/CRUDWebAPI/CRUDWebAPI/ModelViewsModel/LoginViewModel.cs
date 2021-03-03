using CRUDWebAPI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using static System.Net.Mime.MediaTypeNames;

namespace CRUDWebAPI
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices _apiServices = new ApiServices();
        public INavigation Navigation { get; set; }
        public LoginViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
        }


        public string employee { get; set; }
        public string password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {

                    try
                    {
                        var accesstoken = await _apiServices.LoginAsync(employee, password);

                    Settings.token = accesstoken;

                   
                        if (accesstoken != null)
                        {
                            App.Current.MainPage = new CargarClientes();      
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña Icorrectos", "Ok");
                            App.Current.MainPage = new MainPage();
                        }

                    }
                    catch (Exception ex)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "No hay conexion, Intente de nuevo", "Aceptar");
                        App.Current.MainPage = new MainPage();
                    }                                         

                });
            }
        }


        public LoginViewModel()
        {
            employee = Settings.employee;
            password = Settings.password;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
