using Microsoft.AspNetCore.SignalR;

namespace CharitySystem.Hubs
{
    public class EventHub : Hub
    {
        public async Task UpdateEventStats(int eventId, int currentRegistrations, decimal currentFunds)
        {
            await Clients.All.SendAsync("ReceiveEventStatsUpdate", eventId, currentRegistrations, currentFunds);
        }
    }
}
