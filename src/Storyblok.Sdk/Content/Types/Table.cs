using System.Collections.Generic;
using Newtonsoft.Json;

namespace Storyblok.Sdk.Content.Types
{
    public class Table
    {
        [JsonProperty(PropertyName = "tbody")]
        public IEnumerable<TableRow> TableBody { get; set; }

        [JsonProperty(PropertyName = "thead")]
        public IEnumerable<TableHeader> TableHead { get; set; }
    }

    public class TableHeader
    {
        public string Value { get; set; }
    }

    public class TableRow : IContent
    {
        public IEnumerable<TableColumn> Body { get; set; }
    }

    public class TableColumn : IContent
    {
        public string Value { get; set; }
    }
}
