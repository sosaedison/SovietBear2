using UnityEngine;
using System.Collections;

public class TankShell : BulletMotion {

    public GameObject explosion;

	void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
