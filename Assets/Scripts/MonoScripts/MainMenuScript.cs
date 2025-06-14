using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Private
    private AudioManager audioManager;
    [SerializeField]private GameObject Matching;
    FadeAnimScript fadeAnimScript;

    private int coins;

    // Public
    public GameObject roomSystemWindow;
    public CanvasGroup nameIconCanvasG;
    public CanvasGroup lobbyBtnCanvasG;
    
    public CanvasGroup homeMenusCanvasG;
    public CanvasGroup profileSettingCanvasG;
    public CanvasGroup storeCanvasG;

    public SpriteRenderer cardBG;


    public Animator animTrans;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coins = PlayerPrefs.GetInt("PlayerCoins", 10000);

        if (Matching != null && Matching.activeSelf)
        {
            Matching.SetActive(false);
        }
        fadeAnimScript = GetComponent<FadeAnimScript>();

        if(roomSystemWindow != null )
        {
            roomSystemWindow.SetActive(false);
        }
    }

    // Menus Function
    // =====  Play Online  =====
    public void PlayOnline()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        StartCoroutine(LoadMatch("PlayOnline"));
    }

    IEnumerator LoadMatch(string sceneName)
    {
        animTrans.SetTrigger("Exit");

        yield return new WaitForSeconds(1.2f);

        Matching.SetActive(true);
        animTrans.SetBool("MatchLoading", true);

        coins -= 500;
        PlayerPrefs.SetInt("PlayerCoins", coins);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(5f);
        animTrans.SetBool("MatchLoading", false);
        SceneManager.LoadScene(sceneName);

    }

    // =====  Play with Friends  =====
    public void PlayWithFriends()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        if (!roomSystemWindow.gameObject.activeSelf)
        {
            roomSystemWindow.gameObject.SetActive(true);
        }
        else
        {
            roomSystemWindow.gameObject.SetActive(false);
        }
    }



    // =====  Profile Setting  =====
    public void ProfileSetting()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        if (profileSettingCanvasG.alpha == 0f)
        {
            StartCoroutine(ProfileSettingCall());
        }
        
    }

    IEnumerator ProfileSettingCall()
    {
        if (homeMenusCanvasG.alpha != 0f)
        {
            fadeAnimScript.FadeOut(homeMenusCanvasG);
        }
        if (storeCanvasG.alpha != 0f)
        {
            fadeAnimScript.FadeOut(storeCanvasG);
        }
        if (cardBG.color.a != 0f)
        {
            fadeAnimScript.SpriteFadeOut(cardBG);
        }

        fadeAnimScript.FadeOut(nameIconCanvasG);

        if (cardBG.color.a != 0f)
        {
            fadeAnimScript.SpriteFadeOut(cardBG);
        }


        yield return new WaitForSeconds(1f);
        fadeAnimScript.FadeIn(profileSettingCanvasG);

        if (lobbyBtnCanvasG.alpha != 1f)
        {
            fadeAnimScript.FadeIn(lobbyBtnCanvasG);
        }
    }


    // =====  Store  =====
    public void Store()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        StartCoroutine(StoreCalling());
    }

    IEnumerator StoreCalling()
    {
        if (homeMenusCanvasG.alpha != 0f)
        {
            fadeAnimScript.FadeOut(homeMenusCanvasG);
        }
        if (profileSettingCanvasG.alpha != 0f)
        {
            fadeAnimScript.FadeOut(profileSettingCanvasG);
        }

        fadeAnimScript.SpriteFadeOut(cardBG);

        yield return new WaitForSeconds(1f);
        fadeAnimScript.FadeIn(storeCanvasG);

        if (nameIconCanvasG.alpha != 1f)
        {
            fadeAnimScript.FadeIn(storeCanvasG);
        }
        fadeAnimScript.FadeIn(lobbyBtnCanvasG);
    }

    // =====  Lobby  =====
    public void Lobby()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        StartCoroutine(LobbyCalling());
    }

    IEnumerator LobbyCalling()
    {
        if (profileSettingCanvasG.alpha != 0f)
        {
            fadeAnimScript.FadeOut(profileSettingCanvasG);
        }
        if (storeCanvasG.alpha != 0f)
        {
            fadeAnimScript.FadeOut(storeCanvasG);
        }

        fadeAnimScript.FadeOut(lobbyBtnCanvasG);

        yield return new WaitForSeconds(1f);
        fadeAnimScript.FadeIn(homeMenusCanvasG);

        if (nameIconCanvasG.alpha != 1f)
        {
            fadeAnimScript.FadeIn(nameIconCanvasG);
        }
        if (cardBG.color.a != 1f)
        {
            fadeAnimScript.SpriteFadeIn(cardBG);
        }
    }
}
