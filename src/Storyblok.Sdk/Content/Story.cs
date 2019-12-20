using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Storyblok.Sdk.Content
{
    public class Story<T>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("content")]
        public T Content { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("full_slug")]
        public string FullSlug { get; set; }

        [JsonProperty("sort_by_date")]
        public object SortByDate { get; set; }

        [JsonProperty("tag_list")]
        public IEnumerable<string> TagList { get; set; }

        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        [JsonProperty("meta_data")]
        public object MetaData { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("first_published_at")]
        public DateTime FirstPublishedAt { get; set; }

        [JsonProperty("path")]
        public object Path { get; set; }
    }
}
