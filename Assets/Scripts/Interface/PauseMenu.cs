using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class PauseMenu : ButtonHandler {

    LevelManager levelManager;

	// Use this for initialization
	void OnEnable () {
        levelManager = FindObjectOfType<LevelManager>();
	}

    public void ExitToMenu()
    {
        Destroy(levelManager.musicPlayer.gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        levelManager.Unpause();
        gameObject.SetActive(false);
    }
}
