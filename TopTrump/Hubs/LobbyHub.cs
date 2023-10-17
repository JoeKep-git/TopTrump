﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace TopTrump.Hubs
{
    [Authorize]
    public class LobbyHub : Hub
    {
        private static Dictionary<string, List<string>> lobbies = new Dictionary<string, List<string>>();
        public async Task CreateLobby(string lobbyName)
        {
            if (!lobbies.ContainsKey(lobbyName))
            {
                lobbies.Add(lobbyName, new List<string>());
                await Clients.All.SendAsync("UpdateLobbies", lobbyName);
                await Clients.Caller.SendAsync("LobbyCreated", lobbyName);
            }
            else
            {
                await Clients.Caller.SendAsync("LobbyNameExists", lobbyName);
            }

        }

        public async Task JoinLobby(string lobbyName)
        {
            if (lobbies.ContainsKey(lobbyName))
            {
                lobbies[lobbyName].Add(Context.User.Identity.Name); //may need to changing for identity that we use
                await Groups.AddToGroupAsync(Context.ConnectionId, lobbyName);
                await Clients.Group(lobbyName).SendAsync("PlayerJoined", Context.User.Identity.Name);
            }
            else
            {
                await Clients.Caller.SendAsync("LobbyNotFound", lobbyName);
            }
        }
    }

}
