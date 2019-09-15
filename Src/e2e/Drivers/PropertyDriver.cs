using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HomeBid.Services.Bidding.Models;
using HomeBid.Specifications.Setup;
using System.Net;

namespace HomeBid.Specifications.Drivers
{
    public class PropertyDriver
    {
        private HttpClient _httpClient;
        public List<string> Errors;
        public PropertyDriver()
        {
            _httpClient = TestSetup.TestServer.CreateClient();
        }
        public async Task<BiddingProperty> AddBiddingProperty(string title, string askingPrice)
        {
            var content = new StringContent(BuildBiddingProperty(title, askingPrice), UTF8Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync(Post.Properties, content);

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            JObject response = JObject.Parse(jsonResponse);
            if (response["errors"] == null)
            {
                httpResponse.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<BiddingProperty>(jsonResponse);
            }
            else
            {
                Errors = ExtractErrorMessages(jsonResponse);
                return null;
            }
        }

        public async Task<IEnumerable<BiddingProperty>> GetBiddingProperties()
        {
            var httpResponse = await _httpClient.GetAsync(Get.Properties);
            httpResponse.EnsureSuccessStatusCode();
            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var properties = JsonConvert.DeserializeObject<IEnumerable<BiddingProperty>>(jsonResponse);
            return properties;
        }
        public List<string> ExtractErrorMessages(string jsonResponse)
        {
            JObject response = JObject.Parse(jsonResponse);
            JToken titleErrors = response["errors"]["Title"];
            JToken askingPriceErrors = response["errors"]["AskingPrice"];
            var errors = new List<string>();
            if (titleErrors != null)
            {
                foreach (var error in titleErrors)
                {
                    errors.Add((string)error);
                }
            }
            if (askingPriceErrors != null)
            {
                foreach (var error in askingPriceErrors)
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

        public static class Get
        {
            public static string Properties = "api/v1/properties";
        }
    }
}