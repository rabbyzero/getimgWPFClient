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

        [JsonPropertyName("prompt")] public String Prompt { set; get; } = "";
        [JsonPropertyName("width")] public int Width { get; set; } = 1024;
        [JsonPropertyName("height")] public int Height { get; set; } = 1024;
        [JsonPropertyName("steps")] public int Steps { get; set; } = 1;
        [JsonPropertyName("seed")] public int Seed { get; set; } = 1;
        [JsonPropertyName("output_format")] public String Output_format { get; set; } = "jpeg";
        [JsonPropertyName("respone_format")] public String Response_format { get; set; } = "b64";

        public BodyParams() { }
        public RestRequest BuildJsonBody(RestRequest r)
        {
            r.AddJsonBody(this);
            return r;
        }

        public RestRequest BuildJsonBody(RestRequest r, TextToImage<FLUXSchnell> _)
        {
            r.AddJsonBody(new {
                prompt  =   this.Prompt,
                width   =   this.Width,
                height  =   this.Height,
                steps   =   this.Steps,
                seed    =   this.Seed,
                output_format   =   this.Output_format,
                response_format  =   this.Response_format
            });
            return r;
        }
    }
}