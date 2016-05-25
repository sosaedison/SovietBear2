using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    int frameCount = 0;

	void FixedUpdate()
    {
        frameCount++;
        if (frameCount > 30)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.current -= 5;
            }
        }
        
    }
}
