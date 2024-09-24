using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using RestSharp;

namespace getimgWPFClient
{
    internal class RequestBuilder<MODEL,METHOD> where MODEL : ImageModel where METHOD : Pipeline
    {
        public RestRequest request;

        public RequestBuilder()
        {
            request = new RestRequest("v1/flux-schnell/text-to-image", Method.Post)
                .AddHeader("accept","application/json")
                .AddHeader("authorization", "Bearer ")
                .AddJsonBody("",false);
        }

        public RequestBuilder(MODEL model,METHOD method,String key, BodyParams<FLUXSchnell, TextToImage<FLUXSchnell>> _)
        {
            request = new RestRequest(model.ModelLocation + method.pipelineLocation, method.httpMethod)
                .AddHeader("accept", "application/json")
                .AddHeader("authorization", "Bearer " + key);
                
        }
    }
}
