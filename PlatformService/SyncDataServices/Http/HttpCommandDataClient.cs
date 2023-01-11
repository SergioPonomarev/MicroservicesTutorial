using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private const string mediaType = "application/json";
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(
            HttpClient httpClient
            , IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto platform)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platform),
                Encoding.UTF8,
                mediaType);

            var response = await _httpClient.PostAsync($"{_configuration["CommandsService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                System.Console.WriteLine("--> Sync POST to Commands Service was OK!");
            }
            else
            {
                System.Console.WriteLine("--> Sync POST to Commands Service was NOT OK!");
            }
        }
    }
}