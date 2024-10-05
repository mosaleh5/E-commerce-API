using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Services.Services.CacheService;
using System.Text;

namespace Store.Web.Helper
{
    public class CacheAttribute : Attribute , IAsyncActionFilter
    {
        private readonly int _timeToLiveInSecond;

        public CacheAttribute(int timeToLiveInSecond)
        {
            _timeToLiveInSecond = timeToLiveInSecond;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _casheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = await _casheService.GetCacheResponseAsync(cacheKey);

            if (string.IsNullOrEmpty(cachedResponse)) 
            {
                var contextResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contextResult;
                return;
            
            }

            var executedContext =  await next();
            if(executedContext.Result is OkObjectResult response)
            {
                await _casheService.SetCacheResponseAsync(cacheKey, response.Value, TimeSpan.FromSeconds(_timeToLiveInSecond));
            }
            
        }
        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            StringBuilder cacheKey =new StringBuilder();
            cacheKey.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
                cacheKey.Append($"|{key} - {value}");
            return cacheKey.ToString();
        }
    } 
}

