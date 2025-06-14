using TMPro;
using UnityEngine;

public class RoomItem : MonoBehaviour
{
    public TextMeshProUGUI name;

    public void JoinRoom()
    {
        GameObject.Find("RoomSystemManager").GetComponent<RoomSystemManager>().JoinRoomInList(name.text);
    }
}
