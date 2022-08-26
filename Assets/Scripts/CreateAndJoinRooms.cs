using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public static CreateAndJoinRooms Instance;
    [SerializeField] TMP_InputField createInput;
    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] GameObject usernameCanvas;
    [SerializeField] GameObject createRoomCanvas;
    [SerializeField] GameObject joinRoomCanvas;
    [SerializeField] GameObject gameTypeCanvas;
    [SerializeField] TextMeshProUGUI roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject playerListItemPrefab;
    void Awake()
    {
        Instance = this;
    }
    public void SetPlayerName()
    {
        PhotonNetwork.NickName = usernameInput.text;
        usernameCanvas.gameObject.SetActive(false);
    }
    public void ClearUserName()
    {
        usernameInput.text = "";
    }
    public void CreateRoom()
    {
        Debug.Log("Joining Room");
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions { MaxPlayers = 4 });
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        createRoomCanvas.gameObject.SetActive(false);
        joinRoomCanvas.gameObject.SetActive(false);
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            Instantiate(playerListItemPrefab, playerListContent).
            GetComponent<PlayerListItem>().SetUp(player);
        }
    }
    public void ClearGameName()
    {
        createInput.text = "";
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void CreateRoomButton()
    {
        createRoomCanvas.gameObject.SetActive(true);
    }
    public void JoinRoomButton()
    {
        joinRoomCanvas.gameObject.SetActive(true);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform transform in roomListContent)
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }
    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newplayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).
            GetComponent<PlayerListItem>().SetUp(newplayer);
    }
}
