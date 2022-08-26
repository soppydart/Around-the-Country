using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI playerText;
    Photon.Realtime.Player player;
    void Start()
    {
        playerText = GetComponent<TextMeshProUGUI>();
    }
    public void SetUp(Photon.Realtime.Player playerInfo)
    {
        player = playerInfo;
        // Debug.Log(playerInfo.NickName);
        // Debug.Log(playerText.text);
        playerText.text = playerInfo.NickName;
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (player == otherPlayer)
            Destroy(gameObject);
    }
    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
