using System.Text.Json.Serialization;
using RestSharp;

namespace getimgWPFClient
{
    internal class BodyParams<MODEL, MODELMETHOD>
        where MODEL : ImageModel
        where MODELMETHOD : ModelMethod
    {
        //String model;
        //String negative_prompt;
        //String prompt2;
        //String negative_prompt2;
        //String guidance;
        //String scheduler;

        [JsonPropertyName("prompt")] public String prompt { set; get; } = "";
        [JsonPropertyName("width")] public int width { get; set; } = 1024;
        [JsonPropertyName("height")] public int height { get; set; } = 1024;
        [JsonPropertyName("steps")] public int steps { get; set; } = 1;
        [JsonPropertyName("seed")] public int seed { get; set; } = 1;
        [JsonPropertyName("output_format")] public String output_format { get; set; } = "jpeg";
        [JsonPropertyName("respone_format")] public String response_format { get; set; } = "b64";

        public BodyParams() { }
        public RestRequest BuildJsonBody(RestRequest r)
        {
            r.AddJsonBody(this);
            return r;
        }

        public RestRequest BuildJsonBody(RestRequest r, TextToImage<FLUXSchnell> _)
        {
            r.AddJsonBody(new {
                prompt  =   this.prompt,
                width   =   this.width,
                height  =   this.height,
                steps   =   this.steps,
                seed    =   this.seed,
                output_format   =   this.output_format,
                response_format  =   this.response_format
            });
            return r;
        }
    }
}