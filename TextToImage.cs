using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getimgWPFClient
{
    internal class TextToImage: ModelMethod
    {
        TextToImage()
        {
            methodLocation = "text-to-image";
            httpMethod = Method.Post;
        }
    }
}
