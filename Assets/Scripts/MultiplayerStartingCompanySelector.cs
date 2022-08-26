using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerStartingCompanySelector : MonoBehaviour
{
    ExitGames.Client.Photon.Hashtable myCustomProperties = new ExitGames.Client.Photon.Hashtable();
    public void Coaching()
    {
        myCustomProperties["StartingCompany"] = 0;
        PhotonNetwork.SetPlayerCustomProperties(myCustomProperties);
        Debug.Log("AHH");
    }
    public void FlourMill()
    {
        myCustomProperties["StartingCompany"] = 1;
        PhotonNetwork.SetPlayerCustomProperties(myCustomProperties);
    }
    public void Scooba()
    {
        myCustomProperties["StartingCompany"] = 2;
        PhotonNetwork.SetPlayerCustomProperties(myCustomProperties);
    }
    public void Recycle()
    {
        myCustomProperties["StartingCompany"] = 3;
        PhotonNetwork.SetPlayerCustomProperties(myCustomProperties);
    }
}
