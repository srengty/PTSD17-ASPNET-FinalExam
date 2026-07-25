using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Project1WebChat.Hubs;
[Authorize]
public class ChatHub : Hub
{
    public async Task SendMessage(string recipientId, string message)
    {
        var senderId = Context.UserIdentifier;
        var senderName = Context.User?.Identity?.Name;
        await Clients.User(recipientId).SendAsync("ReceiveMessage", senderId, senderName, message);
    }
}
