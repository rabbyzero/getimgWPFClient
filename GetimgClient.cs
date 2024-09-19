using System;
using System.Collections.Generic;
using System.Linq;
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
        RestClient client;

        public GetimgClient()
        {
            client = new RestClient(options, configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }));
        }

        public GetimgClient(string url)
        {
            options = new RestClientOptions(url);
            client = new RestClient(options);
        }
    }
}
