using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour {

    public delegate void PauseChange();
    public static event PauseChange OnPause;
    public static event PauseChange OnUnpause;
    public bool paused; //don't use this directly

    public List<Vector3> bearSightings = new List<Vector3>();
    public int levelNumber = 0;
    public int currentExp;
    public GameObject boss;

    static LevelManager levelManager;

    

	public void GameOver()
    {

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
    }
}
