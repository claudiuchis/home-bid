using System.Text;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HomeBid.Services.Bidding.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using HomeBid.Services.Bidding;

namespace HomeBid.Specifications.Drivers
{
    public class BiddingDriver : WebApplicationFactory<Startup>
    {
        private HttpClient _httpClient;
        private string _jsonResponse;
        public BiddingDriver()
        {
            _httpClient = CreateClient();
        }
        public async Task AddBiddingProperty(string title, string askingPrice)
        {
            var content = new StringContent(BuildBiddingProperty(title, askingPrice), UTF8Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(Post.Properties, content);
            _jsonResponse = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(_jsonResponse);
        }

        public BiddingProperty GetBiddingPropertyAdded()
        {
            JObject response = JObject.Parse(_jsonResponse);
            if (response["errors"] == null)
            {
                return JsonConvert.DeserializeObject<BiddingProperty>(_jsonResponse);
            }
            else
            {
                return null;
            }
        }

        public ArrayList GetErrorMessages()
        {
            JObject response = JObject.Parse(_jsonResponse);
            JToken titleErrors = response["errors"]["Title"];
            JToken askingPriceErrors = response["errors"]["AskingPrice"];
            var errors = new ArrayList();
            if (titleErrors != null)
            {
                foreach(var error in titleErrors)
                {
                    errors.Add((string)error);
                }
            }
            if (askingPriceErrors != null)
            {
                foreach(var error in askingPriceErrors)
                {
                    errors.Add((string)error);
                }
            }
            return errors;
        } 
        private string BuildBiddingProperty(string title, string askingPrice)
        {
            var request = new Dictionary<string, string>();
            request.Add(key: "Title", value: title);
            request.Add(key: "AskingPrice", value: askingPrice);
            return JsonConvert.SerializeObject(request);
        }

        public static class Post
        {
            public static string Properties = "api/v1/properties";
        }
    }
}