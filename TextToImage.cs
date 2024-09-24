using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace getimgWPFClient
{
    internal class TextToImage<MODEL> : Pipeline where MODEL : ImageModel
    {
        TextToImage()
        {
            pipelineLocation = "text-to-image";
            httpMethod = Method.Post;
        }

        public TextToImage(FLUXSchnell _):this()
        {
        }
        public TextToImage(StabelDiffusionXL _) : this()
        {
        }
    }
}
