using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public bool isBoss;
    public int current;
    public int max;
    public int expForKill;
    public GameObject[] potentialDrops;
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
                levelManager.GameOver();
            levelManager.currentExp += expForKill;
            if (isBoss) levelManager.BossDefeated();
            Instantiate(dyingPrefab, transform.position, transform.rotation);
            if (potentialDrops.Length != 0)
            {
                int chance =  Random.Range(0, 3);
                if (chance == 0)
                {
                    int index = Random.Range(0, potentialDrops.Length);
                    Instantiate(potentialDrops[index], transform.position, transform.rotation);
                }
            }
            Destroy(gameObject);
        }
    }
}
