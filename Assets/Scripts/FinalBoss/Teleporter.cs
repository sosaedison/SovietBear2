using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour {

    public Sprite activeSprite;

    bool canTeleport = true;

    public void enableTelporter()
    {
        GetComponent<SpriteRenderer>().sprite = activeSprite;
        canTeleport = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (canTeleport && other.CompareTag("Player"))
        {
            canTeleport = false;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(other.gameObject);
            SceneManager.LoadScene("FinalBossBattle");
            Scene battleScene = SceneManager.GetSceneByName("FinalBossBattle");
            transform.position = new Vector3(138f, 72.18f);
            other.transform.position = new Vector3(138f, 72.18f);
            FindObjectOfType<FinalBossLevelManager>().Pause();
            Destroy(gameObject);
        }
    }
}
