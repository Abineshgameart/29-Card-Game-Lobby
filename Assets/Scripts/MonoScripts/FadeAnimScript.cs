using System.Collections;
using UnityEngine;

public class FadeAnimScript : MonoBehaviour
{
    // Public
    public float fadingDuration = 0.5f;
    

    //  =====  CanvasGroup Fade Animations  =====
    public void FadeIn(CanvasGroup canvasGroup)
    {
        StartCoroutine(Fading(canvasGroup, 0f, 1f));
    }

    public void FadeOut(CanvasGroup canvasGroup)
    {
        StartCoroutine(Fading(canvasGroup, 1f, 0f));
    }

    private IEnumerator Fading(CanvasGroup canvasGroup, float start, float end)
    {
        float elapsed = 0f;

        if (end == 1f)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        while (elapsed < fadingDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsed / fadingDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = end;

        if (end == 0f)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    // =====  Sprite Fade Animation  =====
    public void SpriteFadeIn(SpriteRenderer fadeObject)
    {
        StartCoroutine(SpriteFade(fadeObject, 0f, 1f));
    }

    public void SpriteFadeOut(SpriteRenderer fadeObject)
    {
        StartCoroutine(SpriteFade(fadeObject, 1f, 0f));
    }

    private IEnumerator SpriteFade(SpriteRenderer fadeObject, float start, float end)
    {
        float elapsed = 0f;
        Color realColor = fadeObject.color;

        while (elapsed < fadingDuration)
        {
            float alpha = Mathf.Lerp(start, end,elapsed / fadingDuration);
            fadeObject.color = new Color(realColor.r, realColor.g, realColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        fadeObject.color = new Color(realColor.r, realColor.g, realColor.b, end);

    }
}
