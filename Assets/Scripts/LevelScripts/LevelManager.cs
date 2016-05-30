using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public delegate void PauseChange();
    public static event PauseChange OnPause;
    public static event PauseChange OnUnpause;
    public bool paused; //don't use this directly

    public List<Vector3> bearSightings = new List<Vector3>();
    public int levelNumber = 0;
    public int currentExp;
    public GameObject boss;

    public PlayBackgroundMusic musicPlayer;
    public AudioClip bossMusic;
    public float bossLoop;
    public AudioClip gameOverMusic;

    static LevelManager levelManager;

    public GameObject player;

    public bool levelComplete;

    

	public void GameOver()
    {
        FindObjectOfType<HUDInteraction>().ShowGameOver();
        musicPlayer.PlaySingleLoop(gameOverMusic);
    }

    virtual public void BossDefeated()
    {
        player.GetComponent<AnimateSprite>().staticIndex = 3;
        levelComplete = true;
    }
    
    public static bool isPaused()
    {
        if (!levelManager)
            levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            return false;
        }
        else return levelManager.paused;
    }

    public void StartNewLevel()
    {
        levelManager.levelComplete = false;
        levelManager.bearSightings = new List<Vector3>();
        Unpause();
        FindObjectOfType<HUDManager>().HUD.SetActive(true);
    }

    public void Pause()
    {
        paused = true;
        if (OnPause != null)
            OnPause();
    }
    public void Unpause()
    {
        paused = false;
        if (OnUnpause != null)
            OnUnpause();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (paused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }

        if (levelComplete && Input.GetButtonDown("Strafe"))
        {
            Pause();
            Scene worldMap = SceneManager.GetSceneByName("WorldMap");
            SceneManager.MoveGameObjectToScene(player, worldMap);
            SceneManager.MoveGameObjectToScene(gameObject, worldMap);
            SceneManager.MoveGameObjectToScene(FindObjectOfType<Camera>().gameObject, worldMap);
            FindObjectOfType<GameManager>().LoadNextLevel(this);
        }
    }
}
