using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using Microsoft.Extensions.Options;

using Storyblok.Sdk.Options;

namespace Storyblok.Sdk
{
    public class StoryblokHttpClientHandler : DelegatingHandler
    {
        private readonly StoryblokOptions _options;

        public StoryblokHttpClientHandler(IOptions<StoryblokOptions> options)
        {
            _options = options.Value;
        }

        public StoryblokHttpClientHandler(IOptions<StoryblokOptions> options, HttpClientHandler innerHandler)
        {
            _options = options.Value;
            InnerHandler = innerHandler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(request.RequestUri.AbsoluteUri.Replace("%2F", "/"));
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["token"] = _options.Token;
            query["cv"] = GetCacheTimestamp(_options.Cache).ToString();

            uriBuilder.Query = query.ToString();
            request.RequestUri = uriBuilder.Uri;
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        private long GetCacheTimestamp(StoryblokCache cacheType)
        {
            if (cacheType == StoryblokCache.EveryHour)
            {
                var d = DateTime.UtcNow;
                return ((DateTimeOffset) new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0)).ToUnixTimeSeconds();
            }

            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}
