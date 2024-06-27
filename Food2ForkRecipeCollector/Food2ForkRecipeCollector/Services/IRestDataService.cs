using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2ForkRecipeCollector.Services
{
    public interface IRestDataService
    {
        void PostRequest(string endPoint, string json);
        string GetRequest(string endPoint, string auth);
        void PutRequest(int id);
        void DeleteRequest(int id);
        T Execute<T>(RestRequest request) where T : new();
        void Execute(RestRequest request);
    }
}
