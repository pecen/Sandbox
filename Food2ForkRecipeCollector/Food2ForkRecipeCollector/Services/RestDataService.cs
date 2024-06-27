using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2ForkRecipeCollector.Services
{
    public class RestDataService : IRestDataService
    {
        private RestClient _client;

        public RestDataService(string baseUrl) 
        {
            _client = new RestClient(baseUrl);
        }

        public void DeleteRequest(int id)
        {
            throw new NotImplementedException();
        }

        public string GetRequest(string endPoint, string auth)
        {
            //var request = new RestRequest($"/articles/{articleId}", Method.Get);

            //return client.Execute<Article>(request);

            return string.Empty;
        }

        public void PostRequest(string endPoint, string json)
        {
            var request = new RestRequest(endPoint, Method.Post);
            request.AddJsonBody(json);

            _client.Execute(request);
        }

        public void PutRequest(int id)
        {
            throw new NotImplementedException();
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);
            return response.Data;
        }

        public void Execute(RestRequest request)
        {
            _client.Execute(request);
        }
    }
}
