using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text logText;
    
    void Start()
    {
        PhotonNetwork.NickName = $"Player {Random.Range(0, 1000)}";
        Log($"Player`s name set is {PhotonNetwork.NickName}");

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Log("Connection to Master successful");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions()
        {
            MaxPlayers = 2
        });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Joined room");
        
        PhotonNetwork.LoadLevel("Game");
    }

    void Log(string text)
    {
        Debug.Log(text);
        
        logText.text += $"\n{text}";
    }
}
