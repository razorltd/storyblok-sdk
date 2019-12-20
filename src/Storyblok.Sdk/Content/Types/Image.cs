using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Storyblok.Sdk.Content.Types
{
    public class Image
    {
        [JsonProperty(PropertyName = "name")]
        public string NameOrDescription { get; set; }

        public Uri FileName { get; set; }
    }
}
