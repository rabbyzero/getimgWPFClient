using System.Text.Json.Serialization;

namespace getimgWPFClient
{
    internal class BodyParams<MODEL,MODELMETHOD> 
        where MODEL:ImageModel 
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

        BodyParams() { }
        
    }
}