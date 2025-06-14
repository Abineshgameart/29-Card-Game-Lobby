using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using TMPro;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class RoomLists : MonoBehaviourPunCallbacks
{
    public GameObject roomPrefab;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            
            GameObject Room = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("Content").transform);
            Room.GetComponent<RoomItem>().name.text = roomList[i].Name;
        }
    }
}
