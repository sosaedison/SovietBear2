using UnityEngine;
using System.Collections;

public class ChainsawDamage : MonoBehaviour {

    public int damage;

    void OnTriggerStay2D(Collider2D other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
