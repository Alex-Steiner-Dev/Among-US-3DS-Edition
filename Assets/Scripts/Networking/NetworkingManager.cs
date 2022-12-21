using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkingManager : Photon.PunBehaviour {
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private GameObject player;

    RoomOptions roomOption;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings("1");
        roomOption = new RoomOptions() { IsOpen = true, MaxPlayers = 2, IsVisible = true };
    }

    public override void OnConnectedToMaster()
    {
        GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = ("Connecting to room..");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = ("Room joined!");
        InstantiatePlayer();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = ("Random join failed, creating a new room");
        PhotonNetwork.CreateRoom(null, roomOption, null);
    }

    private void InstantiatePlayer()
    {
        PhotonNetwork.Instantiate(player.name, spawnPosition, Quaternion.identity, 0);
    }
}
