using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace APIcsharp.Classes
{
    public class ActivityLoader
    {
        private readonly string _baseUrl;

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };


        public ActivityLoader(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

       

        public async Task GetActivities(string activityType = "")
        {
            using (var client = new HttpClient()) { 
            try
            {
                string Url = $"{_baseUrl}{activityType}";
                    HttpResponseMessage message = await client.GetAsync(Url);
                    message.EnsureSuccessStatusCode();
                    string content = await message.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(content);
                    Console.WriteLine(data);


                }
                catch (Exception e) {   
                    Console.WriteLine($"Error: {e} ");
                
                }
                
                    
                
                }

        }


    }
}