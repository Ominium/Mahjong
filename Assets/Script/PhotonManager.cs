using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class PhotonManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "v1.0";
    private string userId = "Peisir";
    private void Awake()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

    }
    void Start()
    {
        PhotonNetwork.NickName = userId;

    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();

    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 4;
        PhotonNetwork.CreateRoom("room_1", ro);
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameManager.Instance.isConnect = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
