using RestSharp;

namespace getimgWPFClient
{
    internal class Inpainting<MODEL> : Pipeline where MODEL : ImageModel
    {
        Inpainting()
        {
            pipelineLocation = "inpaint";
            httpMethod = Method.Post;
        }

        public Inpainting(StabelDiffusionXL imageModel) : this()
        {
        }
    }
}