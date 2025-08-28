using HomeApi.Contracts.Models.Home;
using HomeApp.MobileClient.Extensions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeApp.MobileClient.Clients
{
    /// <summary>
    /// Класс-клиент для взаимодействия с внешним сервисом.
    /// Расширять класс HomeApiClient, добавляя в него новые методы по мере необходимости!
    /// </summary>
    public class HomeApiClient
    {
        private HttpClient _client;

        public HomeApiClient(string apiUrl)
        {
            _client = new HttpClient(HttpExtension.GetInsecureHandler()) { BaseAddress = new Uri(apiUrl) };
        }

        /// <summary>
        ///  Метод для вызова InfoResponse на стороне сервера
        /// </summary>
        public async Task<InfoResponse> GetInfo()
        {
            // Получение ответа
            var result = await _client.GetAsync("Home/Info");
            var stringContent = await result.Content.ReadAsStringAsync();
            // Десериализация контракта из Json
            return JsonConvert.DeserializeObject<InfoResponse>(stringContent);
        }
    }
}
