using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Storyblok.Sdk.Content
{
    public abstract class IContent
    {
        [JsonProperty("_uid")]
        string Uid { get; set; }

        [JsonProperty("component")]
        string Component { get; set; }

        [JsonProperty("_editable")]
        string Editable { get; set; }
    }
}
