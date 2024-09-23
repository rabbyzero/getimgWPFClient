namespace getimgWPFClient
{
    internal class ListAllModels:ApiResponse
    {
        public class Model
        {
            public String id { get; set; }
            public String name { get; set; }
            public String family { get; set; }
            public float price { get; set; }
            public DateTime created_at { get; set; }
            public List<String> pipelines { get; set; }
            public Resolution base_resolution { get; set; }

        }
        public List<Model> models { get; set; }
        public ListAllModels() { }
    }

    internal class Resolution
    {
        public int width { get; set; }
        public int height { get; set; }
    }
}
