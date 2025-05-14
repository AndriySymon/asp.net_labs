using System.Net.Http.Json;
using CharitySystem_Shared;

namespace CharitySystem.Client.Services
{
    public class UserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UserModel>> GetUsers() =>
            await _http.GetFromJsonAsync<List<UserModel>>("api/users");

        public async Task<UserModel?> GetUser(int id) =>
            await _http.GetFromJsonAsync<UserModel>($"api/users/{id}");

        public async Task CreateUser(UserModel user) =>
            await _http.PostAsJsonAsync("api/users", user);

        public async Task UpdateUser(UserModel user) =>
            await _http.PutAsJsonAsync($"api/users/{user.Id}", user);

        public async Task DeleteUser(int id) =>
            await _http.DeleteAsync($"api/users/{id}");
    }
}
