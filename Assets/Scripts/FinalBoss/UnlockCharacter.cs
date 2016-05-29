using UnityEngine;
using System.Collections;

public class UnlockCharacter : MonoBehaviour {

    public Sprite[] characterSprites;
    public Sprite[] victorySprites;
    public GameObject newCharacter;
    public GameObject painting;
    public GameObject saveText;
    public GameObject gameWinScreen;
    public GameObject hud;
    public GameObject characterUnlockText;
    public GameObject characterSprite;
    public GameObject cam;

    bool bossDefeated;

    int newCharacterIndex;

    void Start()
    {
        newCharacterIndex = PlayerPrefs.GetInt("UnlockedCharacters", 0) + 1;
        if (newCharacterIndex < 13)
        {
            newCharacter.GetComponent<SpriteRenderer>().sprite = characterSprites[newCharacterIndex];
        }
        else
        {
            newCharacter.SetActive(false);
            painting.SetActive(true);
        }
    }

    public void UnlockCage() // as in, make available, not open
    {
        bossDefeated = true;
        saveText.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = other.gameObject.transform.root.gameObject;
        if (player.CompareTag("Player") && bossDefeated)
        {
            saveText.SetActive(false);
            hud.SetActive(false);
            Instantiate(characterSprite, player.transform.position, player.transform.rotation);
            characterSprite.GetComponent<SpriteRenderer>().sprite = victorySprites[PlayerPrefs.GetInt("CurrentCharacter")];
            Destroy(player);
            cam.transform.position = new Vector3(-20, 89, -10);
            cam.GetComponent<Camera>().orthographicSize = 12;
            if (newCharacterIndex < 12)
            {
                newCharacter.transform.position += Vector3.back;
                newCharacter.GetComponent<SpriteRenderer>().sprite = victorySprites[newCharacterIndex];
                PlayerPrefs.SetInt("UnlockedCharacters", newCharacterIndex);
                PlayerPrefs.Save();
            }
            else
            {
                characterUnlockText.SetActive(false);
            }
            gameWinScreen.SetActive(true);
            //you win
        }
    }
}
