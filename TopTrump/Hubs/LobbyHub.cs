using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace TopTrump.Hubs
{
    [Authorize]
    public class LobbyHub : Hub
    {
        public async Task CreateLobby(string lobbyName)
        {
            // Create a new lobby
            // You may want to add lobby to a list or store in a database
            await Clients.All.SendAsync("UpdateLobbies", lobbyName);
        }

        public async Task JoinLobby(string lobbyName)
        {
            // Add player to the lobby
            // Notify other players in the lobby
            await Clients.All.SendAsync("UpdateLobbies", lobbyName);
        }
    }

}
