using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour {

    public delegate void PauseChange();
    public static event PauseChange OnPause;
    public static event PauseChange OnUnpause;
    public bool paused;

    public List<Vector3> bearSightings = new List<Vector3>();
    public int levelNumber = 0;
    public int currentExp;
    public GameObject boss;

    

	public void GameOver()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            if (paused)
            {
                if (OnPause != null)
                    OnPause();
            }
            else
            {
                if (OnUnpause != null)
                    OnUnpause();
            }
        }
    }
}
