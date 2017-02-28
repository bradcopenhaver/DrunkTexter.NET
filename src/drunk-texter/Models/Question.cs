using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace drunk_texter.Models
{
    public class Question
    {
        public string question { get; set; }
        public string answer { get; set; }
        public DateTime responseDate { get; set; }

        public static JObject GetQuestion(string question)
        {
            Debug.WriteLine(question + "*****************");
            RestClient client = new RestClient("http://localhost:50547");
            RestRequest request = new RestRequest("/EightBall/Index/" + question, Method.GET);
            RestResponse response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            return jsonResponse;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
