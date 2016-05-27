using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

    bool thrown = false;
    Rigidbody2D rigbod;
    GrenadeThrower thrower;
    public GameObject explosion;

    bool paused;
    bool isKinematic;
    Vector2 velocity;

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
        if (thrown && !paused)
        {
            transform.Rotate(0, 0, 10f);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    void OnPause()
    {
        paused = true;
        velocity = rigbod.velocity;
        isKinematic = rigbod.isKinematic;
        rigbod.velocity = Vector2.zero;
        rigbod.isKinematic = true;
    }

    void OnUnpause()
    {
        rigbod.isKinematic = isKinematic;
        rigbod.velocity = velocity;
        paused = false;
    }

    void OnEnable()
    {
        LevelManager.OnPause += OnPause;
        LevelManager.OnUnpause += OnUnpause;
    }

    void OnDisable()
    {
        LevelManager.OnPause -= OnPause;
        LevelManager.OnUnpause -= OnUnpause;
    }
}
