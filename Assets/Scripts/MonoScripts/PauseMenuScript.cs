using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    // Public
    private AudioManager audioManager;
    public GameObject pauseMenuWindow;
    public Animator animTrans;
    // Private

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (pauseMenuWindow != null)
        {
            pauseMenuWindow.SetActive(false);
        }
    }

    public void TogglePauseMenu()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        if (!pauseMenuWindow.gameObject.activeSelf)
        {
            pauseMenuWindow.gameObject.SetActive(true);
        }
        else
        {
            pauseMenuWindow.gameObject.SetActive(false);
        }
    }

    public void LeaveMatch()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
        StartCoroutine(LeavingMatch());
    }

    IEnumerator LeavingMatch()
    {

        animTrans.SetTrigger("Exit");
        pauseMenuWindow.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
