using System.Net.Http.Json;
using CharitySystem.Models;
using CharitySystem_Shared;

namespace CharitySystem.Client.Services
{
    public class EventService
    {
        private readonly HttpClient _http;

        public EventService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Event>> GetEvents() =>
            await _http.GetFromJsonAsync<List<Event>>("api/events");

        public async Task<Event?> GetEvent(int id) =>
            await _http.GetFromJsonAsync<Event>($"api/events/{id}");

        public async Task CreateEvent(Event ev) =>
            await _http.PostAsJsonAsync("api/events", ev);

        public async Task UpdateEvent(Event ev) =>
            await _http.PutAsJsonAsync($"api/events/{ev.Id}", ev);

        public async Task DeleteEvent(int id) =>
            await _http.DeleteAsync($"api/events/{id}");
    }
}
