using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour {

    public Sprite activeSprite;
    public AudioClip bossMusic;

    bool canTeleport = false;

    public void enableTeleporter()
    {
        GetComponent<SpriteRenderer>().sprite = activeSprite;
        canTeleport = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (canTeleport && other.CompareTag("Player"))
        {
            canTeleport = false;
            Health playerHealth = other.gameObject.GetComponent<Health>();
            playerHealth.current = playerHealth.max;
            FindObjectOfType<LevelManager>().musicPlayer.ChangeTrack(bossMusic, 41.143f);
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(other.gameObject);
            SceneManager.LoadScene("FinalBossBattle");
            transform.position = new Vector3(138f, 72.18f);
            other.transform.position = new Vector3(138f, 72.18f);
            FindObjectOfType<FinalBossLevelManager>().Pause();
            Destroy(gameObject);
        }
    }
}
