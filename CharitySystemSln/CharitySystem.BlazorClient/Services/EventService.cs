using CharitySystem.Models;
using System.Net.Http.Json;

public class EventService
{
    private readonly HttpClient _http;

    public EventService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Event>> GetEventsAsync() =>
        await _http.GetFromJsonAsync<List<Event>>("event");

    public async Task<Event?> GetEventByIdAsync(int id) =>
        await _http.GetFromJsonAsync<Event>($"event/{id}");

    public async Task<bool> CreateEventAsync(Event ev)
    {
        var response = await _http.PostAsJsonAsync("event", ev);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateEventAsync(int id, Event ev)
    {
        var response = await _http.PutAsJsonAsync($"event/{id}", ev);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteEventAsync(int id)
    {
        var response = await _http.DeleteAsync($"event/{id}");
        return response.IsSuccessStatusCode;
    }
}
