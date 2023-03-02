using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using Shivan.GraphQL.Connector.Models;

namespace Shivan.GraphQL.Connector.Services
{
    public class VismaBusinessNXTService : IVismaBusinessNXTService
    {
        private readonly IHttpClientFactory _httpClientFactory; 
        
        public VismaBusinessNXTService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Root> GetGithubUser(string base_url , string token)
        {
            var httpClient = _httpClientFactory.CreateClient("vbnxtservice");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" , token);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
            
            string body;
            body = "{\"query\":\"{\\r\\n  availableCustomers {\\r\\n    totalCount\\r\\n    items {\\r\\n      name\\r\\n      vismaNetCustomerId\\r\\n    }\\r\\n  }\\r\\n  \\r\\n  availableCompanies {\\r\\n    totalCount\\r\\n    items {\\r\\n      name\\r\\n      vismaNetCompanyId\\r\\n    }\\r\\n  }\\r\\n}\",\"variables\":{}}";

            var content = new StringContent(body, Encoding.UTF8, "application/json"); 
            
            var response = await httpClient.PostAsync(base_url, content); 
            
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
