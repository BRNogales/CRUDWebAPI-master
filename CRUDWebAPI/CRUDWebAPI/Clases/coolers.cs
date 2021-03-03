using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWebAPI.Clases
{
    class coolers
    {
        public const string resourcePath = "types?entity=platform&page=1";
        public const string resourcePathstructural = "types?entity=StructuralCommunication&page=1";
        public const string resourcePathdinamic = "types?entity=DynamicCommunication&page=1";
        private const string baseUrl = "http://138.197.221.203/api/v1/";
        public List<typlatfom> GetTyplatfoms(string token)
        {
            return JsonConvert.DeserializeObject<List<typlatfom>>(call(resourcePath, new RestRequest(Method.GET), token).Content);
        }

        public List<typlatfom> getstructural(string token)
        {
            return JsonConvert.DeserializeObject<List<typlatfom>>(call(resourcePathstructural, new RestRequest(Method.GET), token).Content);
        }
        public List<typlatfom> getdinamic(string token)
        {
            return JsonConvert.DeserializeObject<List<typlatfom>>(call(resourcePathdinamic, new RestRequest(Method.GET), token).Content);
        }


        protected IRestResponse call(string resourcePath, RestRequest request, string token = null)
        {
            var client = new RestClient($"{baseUrl}{resourcePath}");
            if (token != null)
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }
            client.Timeout = -1;
            return client.Execute(request);
        }
    }
}
