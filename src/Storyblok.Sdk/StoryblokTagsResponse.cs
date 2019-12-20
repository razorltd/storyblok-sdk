using System.Collections.Generic;
using Storyblok.Sdk.Content.Types;

namespace Storyblok.Sdk
{
    public class StoryblokTagsResponse
    {
        public IEnumerable<Tag> Tags { get; set; }
    }
}