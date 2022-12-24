using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class NetworkingManager : Photon.PunBehaviour {
    [SerializeField] private int maxPlayers;

    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private GameObject player;

    RoomOptions roomOption;
    public GameObject thisPlayer;

    private void Awake()
    {
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings("1");

        roomOption = new RoomOptions() { IsOpen = true, MaxPlayers = 10, IsVisible = true };

        Debug.Log("Connected using settings");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room joined!");

        InstantiatePlayer();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("Random join failed, creating a new room");
        PhotonNetwork.CreateRoom(null, roomOption, null);
    }

    private void InstantiatePlayer()
    {
        thisPlayer = PhotonNetwork.Instantiate(player.name, spawnPosition, Quaternion.identity, 0);
        DontDestroyOnLoad(thisPlayer);
    }

    public void LoadGameFunctiom()
    {
        if (PhotonNetwork.isMasterClient)
        {
            int imposter = UnityEngine.Random.Range(0, PhotonNetwork.playerList.Length);
        }

        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        thisPlayer.GetComponent<PlayerController>().LoadCrewmate();
    }

    [PunRPC]
    public void SetImposter()
    {

    }
}
