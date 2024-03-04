
using appSumaConection.Entities;
using Newtonsoft.Json;
using System.Text;

namespace appSumaConection.Services
{
    public class SumaServices : ISumaServices
    {
        private readonly string _baseUrl;

        public SumaServices()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<int> Suma(Suma suma)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(suma), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"Calculos", content);
            
            if(response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<int>(JsonResponse);
                return  result;
            }

            return 0;
        }
    }
}
