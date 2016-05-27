using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public bool isBoss;
    public int current;
    public int max;
    public int expForKill;
    public GameObject dyingPrefab;
    public float damageCooldown;

    bool dead = false;
    float timeOfLastDamage = -1;

    LevelManager levelManager;

	// Use this for initialization
	void Start () {
        current = max;
        levelManager = FindObjectOfType<LevelManager>();
	}

    // Update is called once per frame
    void Update()
    {
        
        if (current > max) current = max;

    }

    public void TakeDamage(int damage)
    {
        if (Time.time - timeOfLastDamage > damageCooldown)
        {
            timeOfLastDamage = Time.time;
            current -= damage;
        }
        if (current <= 0 && !dead)
        {
            dead = true;
            if (CompareTag("Player"))
            {
                levelManager.GameOver();
            }
            levelManager.currentExp += expForKill;
            GameObject dyingSprite = (GameObject)Instantiate(dyingPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
