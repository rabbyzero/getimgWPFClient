using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace getimgWPFClient
{
    internal class TextToImage<MODEL> : ModelMethod where MODEL : ImageModel
    {
        TextToImage()
        {
            methodLocation = "text-to-image";
            httpMethod = Method.Post;
        }

        public TextToImage(FLUXSchnell imageModel):this()
        {
        }

    }
}
