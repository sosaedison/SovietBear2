using UnityEngine;
using System.Collections;

public class EnemyCombat : MonoBehaviour {
    [System.NonSerialized] public PlayerDetectionAI playerDetectionAI;

    // Use this for initialization
    protected virtual void Start () {
        playerDetectionAI = GetComponent<PlayerDetectionAI>();
    }

    public virtual void Attack()
    {
        Vector2 direction = playerDetectionAI.playerInCone.transform.position - transform.position;
        GetComponentInChildren<Weapon>().Shoot(direction);
        GetComponentInChildren<Weapon>().AutoShoot(direction);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (playerDetectionAI.playerVisible && !LevelManager.isPaused())
        {
            Attack();
        }
    }
}
