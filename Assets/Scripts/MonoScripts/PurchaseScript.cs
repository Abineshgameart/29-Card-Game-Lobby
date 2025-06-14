using System.Collections;
using TMPro;
using UnityEngine;

public class PurchaseScript : MonoBehaviour
{
    // private 
    private int coins;

    // Public
    public FadeAnimScript fadeAnimScript;
    public int[] coinbundles;
    public int Coins
    {
        get { return coins; }
        set
        {
            coins = value;
            OnCoinsChanged();
        }
    }

    public TextMeshProUGUI CoinsTxt;
    public CanvasGroup purchasedSuccessMsgcanvasG;

    private void Start()
    {
        Coins = PlayerPrefs.GetInt("PlayerCoins", 10000);
    }

    private void OnCoinsChanged()
    {
            CoinsTxt.text = coins.ToString();
    }
    
    public void PurchaseCoins(int index)
    {
        Coins += coinbundles[index];
        Debug.Log("Purchased");

        PlayerPrefs.SetInt("PlayerCoins", Coins);
        PlayerPrefs.Save();

        StartCoroutine(PurchaseCoinMSg(purchasedSuccessMsgcanvasG));
    }

    IEnumerator PurchaseCoinMSg(CanvasGroup canvasGroup)
    {
        fadeAnimScript.FadeIn(canvasGroup);

        yield return new WaitForSeconds(1f);
        fadeAnimScript.FadeOut(canvasGroup);
    }
}
