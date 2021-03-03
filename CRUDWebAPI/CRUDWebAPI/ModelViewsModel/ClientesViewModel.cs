using CRUDWebAPI.Clases;
using CRUDWebAPI.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Security.Claims;
using Xamarin.Forms;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CRUDWebAPI.ModelViewsModel
{
    class ClientesViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices _apiServices = new ApiServices();
        private List<RutasdeAuditores> _clientes;
        private List<enfriador> _enfriador;
        SaveEnfriador _cooler;
        enfriador _frezer;
        acomooblock _block;
        products _addfrentes;
        incidenceaudit _incidenceau;
        platformaudit _addplatform;
        DynamicCommunication _dynamic;



        public List<RutasdeAuditores> RutasdeAuditores
        {
            get { return _clientes; }
            set
            {
                _clientes = value;
                OnPropertyChanged();
            }

        }

        public List<enfriador> enfriador
        {
            get { return _enfriador; }
            set
            {
                _enfriador = value;
                OnPropertyChanged();
            }

        }

        
        public ICommand GetClientesCommand
        {

            get
            {
                return new Command(async () =>
                {
                try
                {
                    var token = Settings.token;
                    var handler = new JwtSecurityTokenHandler();
                    var tokenjson = handler.ReadJwtToken(token);
                    var id = tokenjson.Claims.First(claim => claim.Type == "id").Value;                      
                    RutasdeAuditores = await _apiServices.GetClientesAsync(token, id);
                    }
                    catch (Exception e)
                    {

                        await Application.Current.MainPage.DisplayAlert("Error", e.ToString(), "OK");
                    }
                    

                    
                });
            }
        }

        public ICommand GetcoolersTypeAsync
        {
            get
            {
                return new Command(async () =>
                {

                    var idcliente = "";
                    if (Application.Current.Properties.ContainsKey("id" +
                        "cliente"))
                    {
                        idcliente = Application.Current.Properties["idcliente"].ToString();
                    }
                    var token = Settings.token;
                    enfriador = await _apiServices.GetcoolersTypeAsync(token, idcliente);
                });
            }
        }

        public ICommand GetcoolersAsync
        {
            get
            {
                return new Command(async () =>
                {

                    var token = Settings.token;
                    enfriador = await _apiServices.GetcoolersAsync(token);
                });
            }
        }
        public Command addcooler
        {
            get
            {
                return new Command(async () =>
                {
                    if (_cooler != null)
                    {
                        _cooler.type = type;
                        _cooler.doors = doors;
                        _cooler.client = client;

                    }
                    else
                    {
                        _cooler = new SaveEnfriador();
                        _cooler.type = type;
                        _cooler.doors = doors;
                        _cooler.client = client;


                    }

                    HttpClient cliente = new HttpClient();
                    var Token = Settings.token;
                    var json = JsonConvert.SerializeObject(_cooler);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var token = JsonConvert.SerializeObject(Token);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    HttpResponseMessage response = await cliente.PostAsync("http://138.197.221.203/api/v1/coolers", content);
                    string result = response.Content.ReadAsStringAsync().Result;
                    Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (response.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.DisplayAlert("Correcto", "El enfriador se agrego Correctamente!", "OK");

                    }
                    else
                    {
                        App.Current.MainPage = new RegistrarEnf();
                        await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");

                    }
                });
            }
        }

        public Command addplatforms
        {
            get
            {
                return new Command(async () =>
                {
                    if (_addplatform != null)
                    {
                        _addplatform.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                        _addplatform.compliesPortpholio = compliesPortpholio;
                        _addplatform.compliesRespect = compliesRespect;
                        _addplatform.compliesCommunication = compliesCommunication;
                        _addplatform.platformType = platformType;
                        _addplatform.exhibitType = exhibitType;
                        _addplatform.totalFronts = totalFronts;

                    }
                    else
                    {
                        _addplatform = new platformaudit();
                        _addplatform.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                        _addplatform.compliesPortpholio = compliesPortpholio;
                        _addplatform.compliesRespect = compliesRespect;
                        _addplatform.compliesCommunication = compliesCommunication;
                        _addplatform.platformType = platformType;
                        _addplatform.exhibitType = exhibitType;
                        _addplatform.totalFronts = totalFronts;




                    }
                   
                    HttpClient cliente = new HttpClient();
                    var Token = Settings.token;
                    var json = JsonConvert.SerializeObject(_addplatform);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var token = JsonConvert.SerializeObject(Token);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    HttpResponseMessage response = await cliente.PostAsync("http://138.197.221.203/api/v1/platforms", content);
                    string result = response.Content.ReadAsStringAsync().Result;
                    JObject rss = JObject.Parse(result);
                    string rssTitle = (string)rss["id"];
                    Application.Current.Properties["uuidplatformsaudit"] = rssTitle;
                    Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (response.IsSuccessStatusCode)
                    {
                        App.Current.MainPage = new photosplataformas();

                    }
                    else
                    {
                        App.Current.MainPage = new plat1();
                        await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");

                    }
                });
            }
        }

        

        public Command invasionesyllenado
        {
            
            get
            {
                              
                return new Command(async () =>
                {
                try
                {
                    if (_frezer != null)
                    {
                            string[] stringArray = new string[] { invasions };
                            _frezer.isInvaded = isInvaded;
                            _frezer.fill75 = fill75;
                            _frezer.firstPosition = firstPosition;
                            _frezer.cooler = "/api/v1/coolers/" + id;
                            _frezer.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                            _frezer.invasions = stringArray;

                        }
                    else
                    {
                        _frezer = new enfriador();
                        string[] stringArray = new string[] { invasions };
                        _frezer.isInvaded = isInvaded;
                        _frezer.fill75 = fill75;
                        _frezer.firstPosition = firstPosition;
                        _frezer.cooler = "/api/v1/coolers/" + id;
                        _frezer.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                        _frezer.invasions = stringArray;


                    }

                    HttpClient cliente = new HttpClient();
                    var Token = Settings.token;
                    var json = JsonConvert.SerializeObject(_frezer);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var token = JsonConvert.SerializeObject(Token);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    HttpResponseMessage response = await cliente.PostAsync("http://138.197.221.203/api/v1/cooler_audits", content);
                    string result = response.Content.ReadAsStringAsync().Result;
                    JObject rss = JObject.Parse(result);
                    string rssTitle = (string)rss["id"];
                    Application.Current.Properties["uuidcoleraudit"] = rssTitle;
                    Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (response.IsSuccessStatusCode)
                    {
                            App.Current.MainPage = new Enf2();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
                        App.Current.MainPage = new Enf1();
                    }
                    }
                    catch (Exception)
                    {
                        await Application.Current.MainPage.DisplayAlert("Oops!", "Este Enfriador ya esta evaluado!", "OK");
                        App.Current.MainPage = new seleccionarcriterioaEv();
                    }
                });
                
            }
        }


        

        public Command acbloque
        {
            get
            {
                return new Command(async () =>
                {
                    if (_block != null)
                    {
                        _block.cooler = "/api/v1/coolers/" + Application.Current.Properties["uuidcooler"].ToString();
                        _block.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                        _block.arrColas = arrColas;
                        _block.arrFruit = arrFruit;
                        _block.arrHyd = arrHyd;
                        _block.arrNcbs = arrNcbs;


                    }
                    else
                    {
                        _block = new acomooblock();
                        _block.cooler = "/api/v1/coolers/" + Application.Current.Properties["uuidcooler"].ToString();
                        _block.audit = "/api/v1/audits/" + Application.Current.Properties["idaudit"].ToString();
                        _block.arrColas = arrColas;
                        _block.arrFruit = arrFruit;
                        _block.arrHyd = arrHyd;
                        _block.arrNcbs = arrNcbs;


                    }

                    HttpClient cliente = new HttpClient();
                    var Token = Settings.token;
                    var json = JsonConvert.SerializeObject(_block);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var token = JsonConvert.SerializeObject(Token);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    HttpResponseMessage response = await cliente.PostAsync("http://138.197.221.203/api/v1/block_arrangments?page=1", content);
                    string result = response.Content.ReadAsStringAsync().Result;
                    Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (response.IsSuccessStatusCode)
                    {
                        App.Current.MainPage = new addfrentesandbotles();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Opps algo ocuirrio mal!", "OK");
                        App.Current.MainPage = new Enf2();
                    }
                });
            }
        }



        string _type;
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value != null)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        string _incidence;
        public string incidence
        {
            get
            {
                return _incidence;
            }
            set
            {
                if (value != null)
                {
                    _incidence = value;
                    OnPropertyChanged();
                }
            }
        }

        string _commentaries;
        public string commentaries
        {
            get
            {
                return _commentaries;
            }
            set
            {
                if (value != null)
                {
                    _commentaries = value;
                    OnPropertyChanged();
                }
            }
        }

        string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        bool _isInvaded;
        public bool isInvaded
        {
            get
            {
                return _isInvaded;
            }
            set
            {
                _isInvaded = value;
                OnPropertyChanged();

            }
        }

        bool _firstPosition;
        public bool firstPosition
        {
            get
            {
                return _firstPosition;
            }
            set
            {
                _firstPosition = value;
                OnPropertyChanged();

            }
        }

        bool _fill75;
        public bool fill75
        {
            get
            {
                return _fill75;
            }
            set
            {
                _fill75 = value;
                OnPropertyChanged();

            }
        }
        string _id;
        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != null)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        string _invasions;
        public string invasions
        {
            get
            {
                return _invasions;
            }
            set
            {
                if (value != null)
                {
                    _invasions = value;
                    OnPropertyChanged();
                }
            }
        }

        string _audit;
        public string audit
        {
            get
            {
                return _audit;
            }
            set
            {
                if (value != null)
                {
                    _audit = value;
                    OnPropertyChanged();
                }
            }
        }
        string _product;
        public string product
        {
            get
            {
                return _product;
            }
            set
            {
                if (value != null)
                {
                    _product = value;
                    OnPropertyChanged();
                }
            }
        }

        string _tradename;
        public string tradename
        {
            get
            {
                return _tradename;
            }
            set
            {
                if (value != null)
                {
                    _tradename = value;
                    OnPropertyChanged();
                }
            }
        }


        string _typeclient;
        public string typeclient
        {
            get
            {
                return _typeclient;
            }
            set
            {
                if (value != null)
                {
                    _typeclient = value;
                    OnPropertyChanged();
                }
            }
        }
        int _doors;
        public int doors
        {
            get
            {
                return _doors;
            }
            set
            {             
                    _doors = value;
                    OnPropertyChanged();
                
            }
        }


        int _totalFronts;
        public int totalFronts
        {
            get
            {
                return _totalFronts;
            }
            set
            {
                _totalFronts = value;
                OnPropertyChanged();

            }
        }

        int _quantity;
        public int quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged();

            }
        }

        int _singleBottles;
        public int singleBottles
        {
            get
            {
                return _singleBottles;
            }
            set
            {
                _singleBottles = value;
                OnPropertyChanged();

            }
        }



        string _client;
        public string client
        {

            get
            {
                return _client;
            }
            set
            {
                if (value != null)
                {
                    _client = value;
                    OnPropertyChanged();
                }
            }
        }


        bool _arrFruit;
        public bool arrFruit
        {
            get
            {
                return _arrFruit;
            }
            set
            {
                _arrFruit = value;
                OnPropertyChanged();

            }
        }

        bool _arrColas;
        public bool arrColas
        {
            get
            {
                return _arrColas;
            }
            set
            {
                _arrColas = value;
                OnPropertyChanged();

            }
        }
        bool _arrNcbs;
        public bool arrNcbs
        {
            get
            {
                return _arrNcbs;
            }
            set
            {
                _arrNcbs = value;
                OnPropertyChanged();

            }
        }
        bool _arrHyd;
        public bool arrHyd
        {
            get
            {
                return _arrHyd;
            }
            set
            {
                _arrHyd = value;
                OnPropertyChanged();

            }
        }


        bool _compliesPortpholio;
        public bool compliesPortpholio
        {
            get
            {
                return _compliesPortpholio;
            }
            set
            {
                _compliesPortpholio = value;
                OnPropertyChanged();

            }
        }

        bool _compliesRespect;
        public bool compliesRespect
        {
            get
            {
                return _compliesRespect;
            }
            set
            {
                _compliesRespect = value;
                OnPropertyChanged();

            }
        }

        bool _compliesCommunication;
        public bool compliesCommunication
        {
            get
            {
                return _compliesCommunication;
            }
            set
            {
                _compliesCommunication = value;
                OnPropertyChanged();

            }
        }

        string _platformType;
        public string platformType
        {

            get
            {
                return _platformType;
            }
            set
            {
                if (value != null)
                {
                    _platformType = value;
                    OnPropertyChanged();
                }
            }
        }


        string _exhibitType;
        public string exhibitType
        {

            get
            {
                return _exhibitType;
            }
            set
            {
                if (value != null)
                {
                    _exhibitType = value;
                    OnPropertyChanged();
                }
            }
        }


        bool _compliesPop1;
        public bool compliesPop1
        {
            get
            {
                return _compliesPop1;
            }
            set
            {
                _compliesPop1 = value;
                OnPropertyChanged();

            }
        }
        bool _compliesPop2;
        public bool compliesPop2
        {
            get
            {
                return _compliesPop2;
            }
            set
            {
                _compliesPop2 = value;
                OnPropertyChanged();

            }
        }
        bool _compliesPop3;
        public bool compliesPop3
        {
            get
            {
                return _compliesPop3;
            }
            set
            {
                _compliesPop3 = value;
                OnPropertyChanged();

            }
        }
        string _dynamicType;
        public string dynamicType
        {

            get
            {
                return _dynamicType;
            }
            set
            {
                if (value != null)
                {
                    _dynamicType = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
