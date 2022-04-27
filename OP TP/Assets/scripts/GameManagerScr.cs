using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScr : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;

    public void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-5f, 5f), 0f);
        
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
    }
    
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName} joined room");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"{otherPlayer.NickName} left room");
    }
}
