using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Storyblok.Sdk.Content.Types
{
    public class Tag
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "taggings_count")]
        public int Taggings { get; set; }
    }
}
