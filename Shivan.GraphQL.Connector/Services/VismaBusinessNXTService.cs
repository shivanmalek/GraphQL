using System.Text;
using System.Net.Http.Json;
using Shivan.GraphQL.Connector.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Shivan.GraphQL.Connector.Services
{
    public class VismaBusinessNXTService : IVismaBusinessNXTService
    {
        private readonly IHttpClientFactory _httpClientFactory; 
        
        public VismaBusinessNXTService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Root> GetGithubUser(string base_url , string token , string query)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" , token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 

            var uri = new Uri(base_url);
            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            var payload = new { query };
            var jsonPayload = JsonConvert.SerializeObject(payload);
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var basicinfo = await response.Content.ReadFromJsonAsync<Root>();
                return basicinfo;
            }
            else
            {
                return default!;
            }
           
        }

    }
}
