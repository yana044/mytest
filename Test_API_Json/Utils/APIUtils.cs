using Newtonsoft.Json;
using RestSharp;
using System;
using Test_API_Json.Utils;

namespace Test_API_Json
{
    public class APIUtils<T>
    {
        public static string Url { get; set; } = TestDataUtils<string>.GetConfigData("url");

        public static RestResponse GetResponse(string key)
        {
            using (var client = new RestClient(Url))
            {
                //var request = new RestRequest(key, Method.Get);
                //var response = client.ExecuteAsync(request).Result;
                var request = new RestRequest(key);
                var response = client.ExecuteGetAsync(request).Result;
                return response;
            }
        }

        public static RestResponse<T> PostResponse(string key, T data)
        {
            using (var client = new RestClient(Url))
            {
                //var newPostJson = JsonConvert.SerializeObject(post);
                //var load = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var newPostJson = JsonConvert.SerializeObject(data);
                var request = new RestRequest(key).AddJsonBody(newPostJson);                        
                var postResponse = client.ExecutePostAsync<T>(request).Result;
                return postResponse;
            }
        }
        public static RestResponse<T> Response(string key, T data = default, string typeofrequest = "Get")
        {
            using (var client = new RestClient(Url))
            {
                switch (typeofrequest)
                {
                    case "Get":
                        {
                            var request = new RestRequest(key);
                            var response = client.ExecuteGetAsync<T>(request).Result;
                            return response;
                        }
                    case "Post":
                        {
                            var newPostJson = JsonConvert.SerializeObject(data);
                            var request = new RestRequest(key).AddJsonBody(newPostJson);
                            var response = client.ExecutePostAsync<T>(request).Result;
                            return response;
                        }
                        default: throw new ArgumentException($"{typeofrequest} does not exist yet");
                }               
            }
        }
    }
}
