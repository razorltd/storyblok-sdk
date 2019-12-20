using Newtonsoft.Json;
using Storyblok.Sdk.Content;

namespace Storyblok.Sdk
{
    public class SingleStoryResponse<T>
    {
        [JsonProperty("story")]
        public Story<T> Story { get; set; }
    }
}