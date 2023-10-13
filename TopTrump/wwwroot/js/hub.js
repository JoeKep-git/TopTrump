"use strict";

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/lobbyHub")
    .build();

connection.start().then(() => {
    // Connection established
}).catch(err => {
    console.error(err.toString());
});

document.getElementById("createLobbyBtn").addEventListener("click", function () {
    let lobbyName = document.getElementById("lobbyNameInput").value;
    connection.invoke("CreateLobby", lobbyName).catch(err => {
        console.error(err.toString());
    });
});

document.getElementById("joinLobbyBtn").addEventListener("click", function () {
    let lobbyName = document.getElementById("lobbyNameInput").value;
    let playerName = document.getElementById("playerNameInput").value;
    connection.invoke("JoinLobby", lobbyName, playerName).catch(err => {
        console.error(err.toString());
    });
});

connection.on("UpdateLobbies", function (lobbyName) {
    var li = document.createElement("li");
    document.getElementById("lobbyList");
    li.textContent = `${lobbyName}`
});
