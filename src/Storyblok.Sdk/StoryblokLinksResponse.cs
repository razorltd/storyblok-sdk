using System.Collections.Generic;

using Newtonsoft.Json;

using Storyblok.Sdk.Content;

namespace Storyblok.Sdk
{
    public class StoryblokLinksResponse
    {
        [JsonProperty("links")]
        public IDictionary<string, Link> Links { get; set; }
    }
}
