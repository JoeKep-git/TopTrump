"use strict";

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/lobbyHub")
    .build();

connection.start().then(() => {
    // Connection established
    console.log("Connection Established");
}).catch(err => {
    console.error(err.toString());
});

document.getElementById("createLobbyBtn").addEventListener("click", function () {
    let lobbyName = document.getElementById("lobbyNameInput").value;
    connection.invoke("CreateLobby", lobbyName).catch(err => {
        console.error(err.toString());
    });
    console.log("testing " + lobbyName);
});
document.getElementById("joinLobbyBtn").addEventListener("click", function () {
    let lobbyName = document.getElementById("lobbyNameInput").value;
    connection.invoke("JoinLobby", lobbyName).catch(err => {
        console.error(err.toString());
    });
});
connection.on("UpdateLobbies", function (lobbyName) {
    var li = document.createElement("li");
    document.getElementById("lobbyList").appendChild(li);
    console.log("This is listing lobbies: " + lobbyName);
    li.textContent = `${lobbyName}`
});

connection.on("LobbyCreated", function (lobbyName) {
    window.location.href = "/lobbyPage?name=" + lobbyName;
});

connection.on("LobbyNameExists", function (lobbyName) {
    // Handle the case where the lobby name already exists
    alert("Lobby name '" + lobbyName + "' already exists. Please choose a different name.");
});

connection.on("PlayerJoined", function (playerName, lobbyName) {
    window.location.href = "/lobbyPage?name=" + lobbyName
});

connection.on("PlayerLeft", function (playerName) {
    // Handle player left event (e.g., update UI)
});