namespace Storyblok.Sdk.Options
{
    public class StoryblokOptions
    {
        public string BaseAddress { get; set; }
        public string Token { get; set; }
        public StoryblokCache Cache { get; set; } = StoryblokCache.NoCache;
        public StoryblokVersion Version { get; set; } = StoryblokVersion.Published;
    }
}
