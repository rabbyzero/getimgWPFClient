using System.Text.Json;
using System.Text.Json.Serialization;
using RestSharp;

namespace getimgWPFClient
{
    internal class BodyParams<MODEL, MODELMETHOD>
            where MODEL : ImageModel
            where MODELMETHOD : Pipeline
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

        public String? model { get; set; }
        public String? negative_prompt { get; set; }
        public String? prompt2 { get; set; }
        public String? negative_prompt2 { get; set; }
        public String? guidance { get; set; }
        public String? scheduler { get; set; }

        static JsonSerializerOptions jsOptions = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
        
        public BodyParams() { }
        public RestRequest BuildJsonBody(RestRequest r)
        {
            r.AddJsonBody(JsonSerializer.Serialize(this,jsOptions));
            return r;
        }

        public RestRequest BuildJsonBody(RestRequest r, TextToImage<FLUXSchnell> _)
        {
            return this.BuildJsonBody(r);
        }

        public RestRequest BuildJsonBody(RestRequest r, TextToImage<StabelDiffusionXL> _)
        {
            return this.BuildJsonBody(r);
        }
    }
}