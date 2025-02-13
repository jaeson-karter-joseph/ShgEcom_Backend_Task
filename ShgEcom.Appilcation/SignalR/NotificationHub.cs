using Microsoft.AspNetCore.SignalR;

namespace ShgEcom.Application.SignalR
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string eventType, string message)
        {
            await Clients.All.SendAsync(eventType, message);
        }
    }
}
