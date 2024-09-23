using RestSharp;

namespace getimgWPFClient
{
    internal class IPAdapter<MODEL> : Pipeline where MODEL : ImageModel
    {
        IPAdapter()
        {
            pipelineLocation = "ip-adapter";
            httpMethod = Method.Post;
        }

        public IPAdapter(StabelDiffusionXL imageModel) : this()
        {
        }
    }
}