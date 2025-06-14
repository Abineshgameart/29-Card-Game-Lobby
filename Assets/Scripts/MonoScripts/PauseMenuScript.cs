using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    // Public
    public GameObject pauseMenuWindow;
    public Animator animTrans;
    // Private

    private void Start()
    {
        if (pauseMenuWindow != null)
        {
            pauseMenuWindow.SetActive(false);
        }
    }

    public void TogglePauseMenu()
    {
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
