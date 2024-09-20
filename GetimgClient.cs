using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.Json;

namespace getimgWPFClient
{
    internal class GetimgClient
    {
        RestClientOptions options = new RestClientOptions("https://api.getimg.ai");
        public RestClient client;
        WebProxy proxy;

        public GetimgClient()
        {
            //proxy = new WebProxy("socks5://127.0.0.1:1084");
            //options = new RestClientOptions("https://api.getimg.ai") { Proxy = proxy }; 
            client = new RestClient(options, configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }));
        }

        public GetimgClient(string url)
        {
            options = new RestClientOptions(url);
            client = new RestClient(options);
        }
    }
}
