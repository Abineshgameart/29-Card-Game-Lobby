using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using TMPro;
using UnityEngine.UIElements;

public class RoomSystemManager : MonoBehaviourPunCallbacks
{
    public GameObject createRoomTxtWindow;
    public GameObject joinRoomTxtWindow;


    public TMP_InputField createRoomNameInput;
    public TMP_InputField joinRoomNameInput;

    public GameObject roomButtonPrefab; // Assign your Room Button prefab
    public Transform contentParent;     // Assign the Content object from ScrollView

    private string generatedRoomCode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (createRoomTxtWindow != null)
        {
            createRoomTxtWindow.SetActive(false);
        }
        if (joinRoomTxtWindow != null)
        {
            joinRoomTxtWindow.SetActive(false);
        }

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void ToggleCreateRoomTxtWindow()
    {
        if (!createRoomTxtWindow.gameObject.activeSelf)
        {
            createRoomTxtWindow.gameObject.SetActive(true);
        }
        else
        {
            createRoomTxtWindow.gameObject.SetActive(false);
        }
    }

    public void ToggleJoinRoomTxtWindow()
    {
        if (!joinRoomTxtWindow.gameObject.activeSelf)
        {
            joinRoomTxtWindow.gameObject.SetActive(true);
        }
        else
        {
            joinRoomTxtWindow.gameObject.SetActive(false);
        }
    }


    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomNameInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomNameInput.text);
    }

    public void JoinRoomInList(string RoomName)
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("PlayWithFriends");
    }


}

