using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductsFilter.Repository.Common
{
    public class HttpRepositoryBase : ReadOnlyRepository
    {
        protected async Task<T> Get<T>(string url) where T : class, new()
        {
            var response = await Get(url);
            var responseResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseResult);
        }

        private async Task<HttpResponseMessage> Get(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return response;
            }
        }
    }
}
