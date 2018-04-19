using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using SpikeXamarin.Domains.Dto;
using System.Collections.Generic;

namespace SpikeXamarin.Infrastructures.Repositories.Http
{
    public class FirstHttpClient
    {
        private static HttpClient client = new HttpClient();

        public FirstHttpClient()
        {
            client.BaseAddress = new Uri("https://api.github.com");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "custom");
            client.Timeout = TimeSpan.FromMilliseconds(10000);

        }

        public async Task<SearchResultDto> fetch(string freeword, int pageNo)
        {
            var parameters = new Dictionary<string, string>(){
                {"q", freeword},{"page", pageNo.ToString()}
            };
            var formUrl = new FormUrlEncodedContent(parameters);
            string query = await formUrl.ReadAsStringAsync();

            SearchResultDto result = null;

            try
            {
                var response = await client.GetAsync("/search/repositories?" + query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SearchResultDto>(content);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(content);
                }
                return result;
            }
            catch (TaskCanceledException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return result;
        }
    }
}