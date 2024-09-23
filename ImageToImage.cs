using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace getimgWPFClient
{
    internal class ImageToImage<MODEL>: Pipeline where MODEL : ImageModel
    {
        ImageToImage()
        {
            pipelineLocation = "image-to-image";
            httpMethod = Method.Post;
        }

        public ImageToImage(StabelDiffusionXL imageModel) : this()
        {
        }
    }
}
