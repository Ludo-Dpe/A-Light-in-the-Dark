using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public PlayerItem playerItemPrefab;
    List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public Transform contentPlayers;

    public GameObject playButton;

    public float timeBetweenUpdates = 1f;
    float nextUpdateTime;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }

    public void OnClickPlayButton()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Go_scene_final");
        }
    }

    public void OnClickCreateRoom()
    {
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 2, BroadcastPropsChangeToAll = true });
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickLeaveRoom()
    {
        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Nom de la Room: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayersList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    void UpdateRoomList(List<RoomInfo> roomList)
    {
        foreach (RoomItem room in roomItemsList)
        {
            Destroy(room.gameObject);
        }

        roomItemsList.Clear();
        foreach (RoomInfo roomInfo in roomList)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(roomInfo.Name);
            roomItemsList.Add(newRoom);
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    void UpdatePlayersList()
    {
        foreach (PlayerItem player in playerItemsList)
        {
            Destroy(player.gameObject);
        }
        playerItemsList.Clear();
        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayer = Instantiate(playerItemPrefab, contentPlayers);
            newPlayer.SetPlayerInfo(player.Value);

            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayer.ApplyLocalChanges();
            }

            playerItemsList.Add(newPlayer);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayersList();
    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        UpdatePlayersList();
    }
}
