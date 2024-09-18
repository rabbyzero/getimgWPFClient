using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using RestSharp;

namespace getimgWPFClient
{
    internal class RequestBuilder<MODEL,METHOD,BODYPARAMS>
    {
        RestRequest request;

        RequestBuilder()
        {
            request = new RestRequest("v1/flux-schnell/text-to-image", Method.Post)
                .AddHeader("accept","application/json")
                .AddHeader("authorization", "Bearer ")
                .AddJsonBody("",false);
        }

        RequestBuilder(MODEL model,METHOD method,String key,BODYPARAMS parameters)
        {

        }
    }
}
