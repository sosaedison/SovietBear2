using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour {

    KeyCode[] konamiCode = new KeyCode[] { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A };
    int currentKeyIndex = 0;

    public GameObject[] Players;

    void Start()
    {
        PlayerPrefs.SetInt("UnlockedCharacters", 0);
        PlayerPrefs.Save();
        UnlockPlayers();
    }

    void UnlockPlayers()
    {
        int playersUnlocked = PlayerPrefs.GetInt("UnlockedCharacters", 0);
        for (int i = 0; i <= playersUnlocked; i++)
        {
            PlayerButton player = Players[i].GetComponent<PlayerButton>();
            player.locked.SetActive(false);
            player.unlocked.SetActive(true);
        }
    }

    public void PlayerSelected(int playerIndex)
    {
        if (playerIndex < 13)
            PlayerPrefs.SetInt("CurrentPlayer", playerIndex);
        SceneManager.LoadScene("WorldMap");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(konamiCode[currentKeyIndex]))
            {
                currentKeyIndex++;
            }
            else
            {
                currentKeyIndex = 0;
            }
        }

        if (currentKeyIndex == konamiCode.Length)  // If currentKeyIndex reaches the length of the konamiCode string, 
        {
            PlayerPrefs.SetInt("UnlockedCharacters", 12);
            PlayerPrefs.Save();
            UnlockPlayers();
        }
    }
}
