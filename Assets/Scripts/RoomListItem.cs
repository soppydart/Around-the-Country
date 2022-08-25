using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    RoomInfo info;
    public void SetUp(RoomInfo roomInfo)
    {
        info = roomInfo;
        buttonText.text = info.Name;
    }
    public void OnClick()
    {
        CreateAndJoinRooms.Instance.JoinRoom(info);
    }
}
