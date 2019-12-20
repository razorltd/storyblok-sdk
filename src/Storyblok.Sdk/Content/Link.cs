using Newtonsoft.Json;

namespace Storyblok.Sdk.Content
{
    public class Link
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_folder")]
        public bool IsFolder { get; set; }

        [JsonProperty("parent_id")]
        public string ParentID { get; set; }

        [JsonProperty("published")]
        public bool IsPublished { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("uuid")]
        public string Uuid  { get; set; }

        [JsonProperty("is_startpage")]
        public bool IsStartpage { get; set; }
        
        [JsonProperty("real_path")]
        public string RealPath { get; set; }
    }
}
