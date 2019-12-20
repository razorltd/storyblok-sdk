using System.Collections.Generic;
using Newtonsoft.Json;
using Storyblok.Sdk.Content;

namespace Storyblok.Sdk
{
    public class MultipleStoryResponse<T>
    {
        [JsonProperty("stories")]
        public IEnumerable<Story<T>> Stories { get; set; }
    }
}