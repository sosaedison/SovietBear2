using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

    bool thrown = false;
    Rigidbody2D rigbod;
    GrenadeThrower thrower;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        rigbod = gameObject.GetComponent<Rigidbody2D>();
        rigbod.isKinematic = true;
	
	}

    public void Throw(GrenadeThrower thrower, Vector2 velocity)
    {
        this.thrower = thrower;
        rigbod.isKinematic = false;
        rigbod.velocity = velocity;
        thrown = true;
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        thrower.Reset();
    }

    void FixedUpdate () {
        if (thrown)
        {
            transform.Rotate(0, 0, 10f);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }
}
