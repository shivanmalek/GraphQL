﻿using System.Text;
using System.Net.Http.Json;
using Shivan.GraphQL.Connector.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL;
using System.ComponentModel.Design;

namespace Shivan.GraphQL.Connector.Services
{
    public class VismaBusinessNXTService : IVismaBusinessNXTService
    {
        private readonly IHttpClientFactory _httpClientFactory; 
        
        public VismaBusinessNXTService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Root> GetNextBasicInfo(string base_url , string token , string query)
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


        public async Task<Models.Association.AssociateObject> PostVBNxt(string base_url, string token, string query)
        {
            //var _client = _httpClientFactory.CreateClient("vismanetservice");
            //_client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            //_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            //var client = new GraphQLHttpClient(new GraphQLHttpClientOptions
            //{
            //   EndPoint = new Uri(base_url),
            //   HttpMessageHandler = new HttpClientHandler
            //   {
            //       AutomaticDecompression = System.Net.DecompressionMethods.Deflate| System.Net.DecompressionMethods.GZip
            //   }
            //} ,new NewtonsoftJsonSerializer(), _client);

            //var request = new GraphQLRequest
            //{
            //    Query = query
            //};

            //var cancellationToken = new CancellationToken();

            //var response = await client.SendMutationAsync<Models.Association.AssociateObject>(request , cancellationToken);

            //return default!;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var uri = new Uri(base_url);
            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            var payload = new { query };
            var jsonPayload = JsonConvert.SerializeObject(payload);
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var basicinfo = await response.Content.ReadFromJsonAsync<Models.Association.AssociateObject>();
                return basicinfo;
            }
            else
            {
                return default!;
            }

        }

    }
}
