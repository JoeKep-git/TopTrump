using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace TopTrump.Hubs
{
    [Authorize]
    public class LobbyHub : Hub
    {
        private static List<string> lobbyNames = new List<string>();
        public async Task CreateLobby(string lobbyName)
        {
            // Create a new lobby
            // You may want to add lobby to a list or store in a database
            if(!lobbyNames.Contains(lobbyName))
            {
                lobbyNames.Add(lobbyName);
                await Clients.All.SendAsync("UpdateLobbies", lobbyName);
            }
            else
            {
                // Lobby name already exists, handle this situation (e.g., inform the user)
                await Clients.Caller.SendAsync("LobbyNameExists", lobbyName);
            }

        }

        public async Task JoinLobby(string lobbyName)
        {
            // Add player to the lobby
            // Notify other players in the lobby
            await Clients.All.SendAsync("UpdateLobbies", lobbyName);
        }
    }

}
