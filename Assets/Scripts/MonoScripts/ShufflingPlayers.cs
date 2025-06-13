using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShufflingPlayers : MonoBehaviour
{
    // Public 
    public RandomPlayers[] randomPlayers;

    public int numberOfSlots = 3;
    public Image[] playersAvatar;
    public TextMeshProUGUI[] playersName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomPlayerAssiging();
    }

    private void RandomPlayerAssiging()
    {
        RandomPlayers[] shuffledPlayers = (RandomPlayers[]) randomPlayers.Clone();

        for (int i = 0; i < shuffledPlayers.Length; i++)
        {
            int randomIndex = Random.Range(i, shuffledPlayers.Length);
            var temp = shuffledPlayers[i];
            shuffledPlayers[i] = shuffledPlayers[randomIndex];
            shuffledPlayers[randomIndex] = temp;
        }

        for (int i = 0; i < numberOfSlots; i++)
        {
            playersAvatar[i].sprite = shuffledPlayers[i].avatarImg;
            playersName[i].text = shuffledPlayers[i].name;
        }
    }
}
