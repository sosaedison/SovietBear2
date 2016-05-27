using UnityEngine;
using System.Collections;

public class FlameScript : MonoBehaviour {

    public float bulletSpeed;
    public int flameLife = 0;
    public Vector2 direction;
    private int speedFactor = 1;
	private SpriteRenderer spriteRendererName;
	private float objectAlpha = 1.0f;
   // public ParticleAnimator particleFire;

    // Use this for initialization
    void Start()
    {
		spriteRendererName = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.isPaused())
        {
            if (direction.x < 0)
            {
                speedFactor = -1;
            }
            ++flameLife;
            transform.Translate(Vector3.right * bulletSpeed * speedFactor * Time.deltaTime);
            transform.Translate(Vector3.up * Random.Range(-2f, 2f) * Time.deltaTime);
            if (flameLife == 110)
            {
                Destroy(gameObject);
            }
            objectAlpha = objectAlpha - .007f;
            spriteRendererName.color = new Color(1f, 1f, 1f, objectAlpha);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.current -= 1;
        }
        Destroy(gameObject);

    }
}
