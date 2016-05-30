using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject[] bosses;
    public GameObject[] players;
    public AudioClip[] music;
    public float[] musicLoopPoints;
    public PlayBackgroundMusic musicPlayer;
    public GameObject levelManagerPrefab;
    public GameObject marker;
    public GameObject map;
    public GameObject continueText;

    bool nextSceneLoaded;
    bool nextSceneReady;
    bool startedMusic;
    Scene nextScene;
    LevelManager currentLevelManager;
    GameObject playerPrefab;
    //animate marker
    Vector3 startPos;
    Vector3 endPos;
    float startTime = 0;
    public float markerSpeed;
    float totalDistance;
    float lerpTime;

    void Awake()
    {
        SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive);
        nextScene = SceneManager.GetSceneByName("Level");
        currentLevelManager = (LevelManager)Instantiate(levelManagerPrefab).GetComponent<LevelManager>();
        playerPrefab = players[PlayerPrefs.GetInt("CurrentPlayer", 0)];
        currentLevelManager.player = (GameObject)Instantiate(playerPrefab, Vector3.zero + Vector3.back * .3f, Quaternion.identity);
        currentLevelManager.Pause();
        currentLevelManager.boss = bosses[0];
        musicPlayer = FindObjectOfType<PlayBackgroundMusic>();
        currentLevelManager.musicPlayer = musicPlayer;
        

        ResetMarker();
        marker.GetComponent<AnimateSprite>().animatedSprites = playerPrefab.GetComponent<AnimateSprite>().animatedSprites;
    }

    public void LoadNextLevel(LevelManager levelManager)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("WorldMap"));
        Camera cam = FindObjectOfType<Camera>();
        cam.transform.position = Vector3.zero + Vector3.back * 10f;
        cam.GetComponent<MoveCamera>().endPos = Vector3.zero + Vector3.back * 10f;
        map.SetActive(true);
        SceneManager.UnloadScene("Level");
        string nextLevelName;
        int musicIndex;
        if (levelManager.levelNumber == 2)
        {
            nextLevelName = "LabLevel";
            musicIndex = 3;
        }
        else
        {
            nextLevelName = "Level";
            musicIndex = Random.Range(0, 3);
        }
        musicPlayer.ChangeTrack(music[musicIndex], musicLoopPoints[musicIndex]);
        SceneManager.LoadSceneAsync(nextLevelName, LoadSceneMode.Additive);
        nextScene = SceneManager.GetSceneByName(nextLevelName);
        RefreshPlayer(levelManager.player);
        levelManager.levelNumber++;
        levelManager.boss = bosses[levelManager.levelNumber];
        currentLevelManager = levelManager;
        ResetMarker();

    }

    void RefreshPlayer(GameObject player)
    {
        player.transform.position = Vector3.zero + Vector3.back * .3f;
        Weapon[] weapons = player.GetComponentsInChildren<Weapon>();
        foreach (Weapon weapon in weapons)
        {
            weapon.ammo += (int) ((float)weapon.maxAmmo * .25f);
        }
        Health playerHealth = player.GetComponent<Health>();
        playerHealth.current = playerHealth.max;
    }

    void ResetMarker()
    {
        startPos = marker.transform.position;
        endPos = marker.transform.position + Vector3.right * 11.6f;
        totalDistance = Vector3.Distance(startPos, endPos);
        lerpTime = totalDistance / markerSpeed;
        startTime = Time.time;
    }

    void Update()
    {
        
        if (currentLevelManager)
        {
            if (!nextSceneLoaded && nextScene.isLoaded)
            {
                if (nextSceneReady)
                {
                    nextScene.GetRootGameObjects();
                    nextSceneLoaded = true;
                    continueText.SetActive(true);
                    SceneManager.SetActiveScene(nextScene);
                    if (!startedMusic)
                    {
                        int musicIndex = Random.Range(0, 3);
                        musicPlayer.ChangeTrack(music[musicIndex], musicLoopPoints[musicIndex]);
                        startedMusic = true;
                    }
                }
            }
            if (nextSceneLoaded && Input.anyKeyDown) 
            {
                SceneManager.MoveGameObjectToScene(currentLevelManager.player, nextScene);
                SceneManager.MoveGameObjectToScene(currentLevelManager.gameObject, nextScene);
                SceneManager.MoveGameObjectToScene(FindObjectOfType<Camera>().gameObject, nextScene);
                currentLevelManager.StartNewLevel();
                nextSceneLoaded = false;
                nextSceneReady = false;
                continueText.SetActive(false);
                currentLevelManager = null;
                map.SetActive(false);
                
            }
        }

        //move marker
        float currentTime = Time.time - startTime;
        if (marker)
            marker.transform.position = Vector3.Lerp(startPos, endPos, currentTime / lerpTime);
    }

    void OnFinishedGeneration()
    {
        nextSceneReady = true;
    }

    void OnFailedGeneration()
    {
        string nextLevelName;
        nextSceneLoaded = false;
        if (currentLevelManager.levelNumber == 3)
        {
            nextLevelName = "LabLevel";
        }
        else
        {
            nextLevelName = "Level";
        }
        SceneManager.UnloadScene(nextLevelName);
        SceneManager.LoadSceneAsync(nextLevelName, LoadSceneMode.Additive);
        nextScene = SceneManager.GetSceneByName(nextLevelName);
    }

    void OnEnable()
    {
        LevelBuilder.OnFinishedGeneration += OnFinishedGeneration;
        LevelBuilder.OnFailedGeneration += OnFailedGeneration;
    }

    void OnDisable()
    {
        LevelBuilder.OnFinishedGeneration -= OnFinishedGeneration;
        LevelBuilder.OnFailedGeneration -= OnFailedGeneration;
    }
}
