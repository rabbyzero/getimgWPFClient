using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace getimgWPFClient
{
    internal class StabelDiffusionXL : ImageModel
    {
        public StabelDiffusionXL()
        {
            modelLocation = "v1/stable-diffusion-xl";
        }
        public Type[] modeMethods()
        {
            return new Type[] { 
                typeof(TextToImage<StabelDiffusionXL>),
                typeof(ImageToImage<StabelDiffusionXL>),
                typeof(Inpainting<StabelDiffusionXL>),
                typeof(IPAdapter<StabelDiffusionXL>)
            };
        }
    }
}
