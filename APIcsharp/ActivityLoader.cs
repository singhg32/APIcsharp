using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace APIcsharp.Class
{
    public class ActivityLoader
    {
        private string Activity { get; set; }
        public string Type {
            get
            
              
                ; set; }
        private string Participants { get; set; }
        private string Accessibility { get; set; }
        private string Price { get; set; }


        private readonly string _baseUrl;

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };


        public ActivityLoader(string baseUrl)
        {
            _baseUrl = baseUrl;
        }



        public async Task GetActivities(string activityType = "",string participants = "")
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string Url = $"{_baseUrl}type={activityType}&participants={participants}";
                    HttpResponseMessage message = await client.GetAsync(Url);
                    message.EnsureSuccessStatusCode();
                    string content = await message.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(content);
                    Activity = data["activity"];
                    Type = (data["type"]).ToString().ToLower();
                    Participants = data["participants"];
                    Price = data["price"];
                    Accessibility = data["accessibility"];


                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e} ");

                }



            }

        }

        public void DisplayData()
        {
            try
            {

                Console.WriteLine($"You should {Activity.ToLower()}");

                Console.WriteLine($"Tags:\n     Type: {Type.ToUpper()} \n     Participants: {Participants.ToLower()} \n \n");
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine($"Unfortunately there are no activities with these parameters. Please reenter");
            }
        }


    }
}