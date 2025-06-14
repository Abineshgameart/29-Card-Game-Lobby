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
    public Avatars avatars;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadingCoins(coinsTxt);

        LoadingProfileName(profileNameTxt);

        AvatarLoading(avatarImg);
    }

    public void LoadingCoins(TextMeshProUGUI changeCoinsTxt)
    {
        coins = PlayerPrefs.GetInt("PlayerCoins", 10000);
        changeCoinsTxt.text = coins.ToString();
    }

    public void LoadingProfileName(TextMeshProUGUI changeProfileNameTxt)
    {
        profileName = PlayerPrefs.GetString("ProfileName", "XXXYYY");
        changeProfileNameTxt.text = profileName;
    }

    public void AvatarLoading(Image changeAvatar)
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
            changeAvatar.sprite = newSprite;
        }
        else if (avatarIndex < 4)
        {
            changeAvatar.sprite = avatars.avatarSprites[avatarIndex];
        }
    }

}
