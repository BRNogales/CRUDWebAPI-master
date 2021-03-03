using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUDWebAPI.Clases
{
    class UploadImages
    {
        private const string baseUrl = "http://138.197.221.203/api/v1/cooler_audits/";
        private const string baseUrlentry = "http://138.197.221.203/api/v1/clients/";
        private const string baseUrldinamic = "http://138.197.221.203/api/v1/dynamic_communications/";
        public IRestResponse uploadposition(Label label) {

                string id = Application.Current.Properties["uuidcoleraudit"].ToString();
                var client = new RestClient(baseUrl + $"{id}/position_picture");
                var request = new RestRequest(Method.POST);
                var Token = Settings.token;
                request.AddHeader("Authorization", "Bearer " + Token);
                request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
                request.AddFile("positionPicture", label.Text);
                request.AlwaysMultipartFormData = true;
                return client.Execute(request);
        }
        public IRestResponse uploadfrontspicture(Label label)
        {

                string id = Application.Current.Properties["uuidcoleraudit"].ToString();
                var client = new RestClient(baseUrl + $"{id}/fronts_picture");
                var request = new RestRequest(Method.POST);
                var Token = Settings.token;
                request.AddHeader("Authorization", "Bearer " + Token);
                request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
                request.AddFile("frontsPicture", label.Text);
                request.AlwaysMultipartFormData = true;
                return client.Execute(request);
        }

        public IRestResponse uploadcoolerpicture(Label label)
        {
                string id = Application.Current.Properties["uuidcoleraudit"].ToString();
                var client = new RestClient(baseUrl + $"{id}/cooler_picture");
                var request = new RestRequest(Method.POST);
                var Token = Settings.token;
                request.AddHeader("Authorization", "Bearer " + Token);
                request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
                request.AddFile("coolerPicture", label.Text);
                request.AlwaysMultipartFormData = true;
                return client.Execute(request);

        }
        public IRestResponse uploadimaenty(Label label)
        {
            string id = Application.Current.Properties["idcliente"].ToString();
            var client = new RestClient(baseUrlentry + $"{id}/entry_picture");
            var request = new RestRequest(Method.POST);
            var Token = Settings.token;
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
            request.AddFile("entryPicture", label.Text);
            request.AlwaysMultipartFormData = true;
            return client.Execute(request);

        }

        public IRestResponse uploadimadinamic(Label label)
        {
            string id = Application.Current.Properties["uuiddinamic"].ToString();
            var client = new RestClient(baseUrldinamic + $"{id}/picture");
            var request = new RestRequest(Method.POST);
            var Token = Settings.token;
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
            request.AddFile("dynamicPicture", label.Text);
            request.AlwaysMultipartFormData = true;
            return client.Execute(request);

        }


    }
    
}
