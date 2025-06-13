using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Private
    [SerializeField]private GameObject Matching;
    FadeAnimScript fadeAnimScript;

    public CanvasGroup nameIconCanvasG;
    public CanvasGroup lobbyBtnCanvasG;
    
    public CanvasGroup homeMenusCanvasG;
    public CanvasGroup profileSettingCanvasG;
    public CanvasGroup storeCanvasG;

    public SpriteRenderer cardBG;

    // Public
    public Animator animTrans;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Matching != null && Matching.activeSelf)
        {
            Matching.SetActive(false);
        }
        fadeAnimScript = GetComponent<FadeAnimScript>();
    }

    // Menus Function
    // =====  Play Online  =====
    public void PlayOnline()
    {
        StartCoroutine(LoadMatch("PlayOnline"));
    }

    IEnumerator LoadMatch(string sceneName)
    {
        animTrans.SetTrigger("Exit");

        yield return new WaitForSeconds(1.2f);

        Matching.SetActive(true);
        animTrans.SetBool("MatchLoading", true);

        yield return new WaitForSeconds(5f);
        animTrans.SetBool("MatchLoading", false);
        SceneManager.LoadScene(sceneName);

    }


    // =====  Profile Setting  =====
    public void ProfileSetting()
    {
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
        fadeAnimScript.SpriteFadeOut(cardBG);

        
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
