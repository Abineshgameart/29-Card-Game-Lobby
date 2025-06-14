using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("===== Audio Source =====")]
    [SerializeField]AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("===== Audio Clips =====")]
    public AudioClip background;
    public AudioClip coinPurchased;
    public AudioClip buttonClick;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
