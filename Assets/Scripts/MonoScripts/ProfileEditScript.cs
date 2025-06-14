using System;
using System.Collections;
using System.IO;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileEditScript : MonoBehaviour
{
    // Public
    public GameObject profileNameEditWindow;
    public TMP_InputField nameField;
    public TextMeshProUGUI[] profileNameTxt;

    public GameObject avatarEditWindowToggle;
    public Image[] avatarImgs;
    public Sprite[] avatarSprites;

    private void Awake()
    {
        if (profileNameEditWindow != null)
        {
            profileNameEditWindow.SetActive(false);
        }
        if (avatarEditWindowToggle != null)
        {
            avatarEditWindowToggle.SetActive(false);
        }
    }

    // =====  Name Edit  =====

    public void NameEditWindowToggle()
    {
        if (profileNameEditWindow != null)
        {
            if(!profileNameEditWindow.gameObject.activeSelf)
            {
                profileNameEditWindow.gameObject.SetActive(true);
            } else
            {
                profileNameEditWindow.gameObject.SetActive(false);
            }
        }
    }

    public void ChangeName ()
    {
        string newName = nameField.text;

        foreach (TextMeshProUGUI text in profileNameTxt)
        {
            text.text = newName;
        }

        PlayerPrefs.SetString("ProfileName", newName);
        PlayerPrefs.Save();

        NameEditWindowToggle();
    }

    // =====  Avatar Edit  =====

    public void AvatarEditWindowToggle()
    {
        if (!avatarEditWindowToggle.gameObject.activeSelf)
        {
            avatarEditWindowToggle.gameObject.SetActive(true);
        }
        else
        {
            avatarEditWindowToggle.gameObject.SetActive(false);
        }
    }

    public void SelectAvatar(int index)
    {
        foreach (Image image in avatarImgs)
        {
            image.sprite = avatarSprites[index];
        }

        PlayerPrefs.SetInt("AvatarIndex", index);
        PlayerPrefs.Save();

    }


    public void UploadImage()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Choose an Image", "", "png,jpg,jpeg", false);

        if (paths.Length > 0 && File.Exists(paths[0]))
        {
            StartCoroutine(LoadingImage(paths[0]));
        }
    }

    private IEnumerator LoadingImage(string filePath)
    {
        byte[] imageBytes = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imageBytes);

        // Convert to Sprite
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        // Set to Image
        foreach(Image image in avatarImgs)
        {
            image.sprite = newSprite;
        }

        PlayerPrefs.SetInt("AvatarIndex", 4);
        PlayerPrefs.SetString("AvatarImgPath", filePath);
        PlayerPrefs.Save();

        yield return null;
    }

}
