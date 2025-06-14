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


    public TMP_InputField roomNameInput;

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



    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInput.text))
        {
            return;
        }

        generatedRoomCode = GenerateNumericRoomCode();

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;

        Hashtable customProperties = new Hashtable();
        customProperties.Add("RoomCode", generatedRoomCode);

        roomOptions.CustomRoomProperties = customProperties;


        PhotonNetwork.CreateRoom(roomNameInput.text, roomOptions);

        ToggleCreateRoomTxtWindow();

    }

    private string GenerateNumericRoomCode()
    {
        int length = 5;
        string code = "";

        for (int i = 0; i < length; i++)
        {
            code += Random.Range(0, 10).ToString();
        }

        return code;
    }


    public override void OnCreatedRoom()
    {
         // Instantiate button in the Scroll View
        GameObject roomButton = Instantiate(roomButtonPrefab, contentParent);

        // Get and set texts on the button
        roomButton.transform.Find("RoomName").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.Name;
        roomButton.transform.Find("RoomCode").GetComponent<Text>().text = "Code: " + generatedRoomCode;

        
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room Creation Failed: " + message);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server");
        PhotonNetwork.JoinLobby();
    }

}
