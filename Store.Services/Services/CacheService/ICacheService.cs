using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.CacheService
{
    public interface ICacheService
    {
        Task SetCacheResponseAsync(string key, object response, TimeSpan timeLive);
        Task<string> GetCacheResponseAsync(string key);

    }
}
