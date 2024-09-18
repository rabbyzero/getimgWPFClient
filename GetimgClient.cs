using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Extensions;

namespace getimgWPFClient
{
    internal class GetimgClient
    {
        RestClientOptions options ;
        RestClient client;

        GetimgClient()
        {
            options = new RestClientOptions("https://api.getimg.ai");
            client = new RestClient(options);
        }

        GetimgClient(string url)
        {
            options = new RestClientOptions(url);
            client = new RestClient(options);
        }
    }
}
