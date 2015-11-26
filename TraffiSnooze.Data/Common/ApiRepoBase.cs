using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TraffiSnooze.Data.Common
{

    public class ComicVineApiRepo
    {

        private HttpClient client;

        public ComicVineApiRepo(string baseAddress)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
        }

        private async Task<string> GetStringAsync(string requestRelativeUri, IEnumerable<UrlParam> parameters)
        {
            requestRelativeUri = requestRelativeUri.TrimEnd('/').TrimStart('/');
            StringBuilder bldr = new StringBuilder();
            bldr.Append($"{requestRelativeUri}/");

            foreach (var param in parameters)
            {
                bldr.Append(param.ToString());
            }
            var response = await client.GetAsync(bldr.ToString());
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else throw new Exception("Request failed" + response.ToString());
        }

        private Task<string> GetStringAsync(string requestRelativeUri, params UrlParam[] parameters)
        {
            return GetStringAsync(requestRelativeUri, parameters.ToList());
        }

        public async Task<T> GetAsync<T>(string requestRelativeUri, params UrlParam[] parameters)
        {
            string json = await GetStringAsync(requestRelativeUri, parameters.ToList());
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        public async Task<T> GetAsync<T>(string requestRelativeUri)
        {
            string json = await GetStringAsync(requestRelativeUri, new List<UrlParam>());
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}

