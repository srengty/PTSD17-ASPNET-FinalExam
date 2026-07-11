using System.Net.WebSockets;

namespace Project1WebChat.Services;
public interface IChatService
{
    public Task Echo(WebSocket webSocket);
}