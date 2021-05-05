using System.Net.Http;
using System.Threading.Tasks;

using Refit;

namespace Storyblok.Sdk
{
    public interface IStoryblokClient
    {
        [Get("/links")]
        Task<StoryblokLinksResponse> GetLinksAsync([Query] [AliasAs("starts_with")] string startsWith);

        [Get("/tags")]
        Task<StoryblokTagsResponse> GetTagsAsync([Query] [AliasAs("starts_with")] string startsWith);

        [Get("/stories")]
        Task<HttpResponseMessage> GetStoriesByTagAsync<T>(
            [Query] [AliasAs("starts_with")] string startsWith,
            [Query] [AliasAs("with_tag")] string withTag,
            [Query] [AliasAs("per_page")] int? perPage = 100,
            [Query] [AliasAs("page")]int? page = 1,
            [Query] [AliasAs("sort_by")]string sortBy = "first_published_at:desc",
            [Query] [AliasAs("language")]string language = "en");

        [Get("/stories")]
        Task<MultipleStoryResponse<T>> FilterStoriesWithFullTextSearchAsync<T>(
            [Query] [AliasAs("starts_with")] string startsWith,
            [Query] [AliasAs("search_term")] string searchTerm,
            [Query][AliasAs("language")] string language = "en");

        [Get("/stories")]
        Task<HttpResponseMessage> GetStories<T>(
            [Query] [AliasAs("starts_with")] string startsWith,
            [Query] [AliasAs("per_page")]int? perPage = 100,
            [Query] [AliasAs("page")]int? page = 1,
            [Query] [AliasAs("sort_by")]string sortBy = "first_published_at:desc",
            [Query][AliasAs("language")] string language = "en");

        [Get("/stories")]
        Task<HttpResponseMessage> GetAllStories<T>(
            [Query] [AliasAs("per_page")]int? perPage = 100,
            [Query] [AliasAs("page")]int? page = 1,
            [Query] [AliasAs("sort_by")]string sortBy = "first_published_at:desc",
            [Query][AliasAs("language")] string language = "en");

        [Get("/stories/{fullSlug}")]
        Task<SingleStoryResponse<T>> GetStory<T>(string fullSlug,
            [Query][AliasAs("language")] string language = "en");
    }
}
