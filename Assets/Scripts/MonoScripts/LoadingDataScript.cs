using TMPro;
using SFB;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LoadingDataScript : MonoBehaviour
{
    // Private
    private string profileName;
    private int coins;
    private int avatarIndex;
    private string avatarImgPath;
    

    // Public 
    public TextMeshProUGUI coinsTxt;
    public TextMeshProUGUI profileNameTxt;
    public Image avatarImg;
    public Sprite[] avatarSprites; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadingCoins();

        LoadingProfileName();

        AvatarLoading();
    }

    private void LoadingCoins()
    {
        coins = PlayerPrefs.GetInt("PlayerCoins", 10000);
        coinsTxt.text = coins.ToString();
    }

    private void LoadingProfileName()
    {
        profileName = PlayerPrefs.GetString("ProfileName", "XXXYYY");
        profileNameTxt.text = profileName;
    }

    private void AvatarLoading()
    {
        avatarIndex = PlayerPrefs.GetInt("AvatarIndex", 0);

        if (avatarIndex == 4)
        {
            avatarImgPath = PlayerPrefs.GetString("AvatarImgPath", "");
            byte[] imageBytes = File.ReadAllBytes(avatarImgPath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageBytes);

            // Convert to Sprite
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            // Set to Image
            avatarImg.sprite = newSprite;
        }
        else if (avatarIndex < 4)
        {
            avatarImg.sprite = avatarSprites[avatarIndex];
        }
    }

}
