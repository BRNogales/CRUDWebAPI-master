using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRUDWebAPI.Clases
{
    class Uploadimagesplat
    {
        private const string baseUrl = "http://138.197.221.203/api/v1/cooler_audits/";

        private const string baseUrlplat = "http://138.197.221.203/api/v1/platforms/";

        public IRestResponse uploadplatfront(Label label)
        {

            string id = Application.Current.Properties["uuidplatformsaudit"].ToString();
            var client = new RestClient(baseUrlplat + $"{id}/frontal_picture");
            var request = new RestRequest(Method.POST);
            var Token = Settings.token;
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
            request.AddFile("frontalPicture", label.Text);
            request.AlwaysMultipartFormData = true;
            return client.Execute(request);
        }
        public IRestResponse uploadplatcost(Label label)
        {

            string id = Application.Current.Properties["uuidplatformsaudit"].ToString();
            var client = new RestClient(baseUrlplat + $"{id}/side_picture");
            var request = new RestRequest(Method.POST);
            var Token = Settings.token;
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AddHeader("Cookie", "XDEBUG_SESSION=PHPSTORM");
            request.AddFile("sidePicture", label.Text);
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
    }
}
