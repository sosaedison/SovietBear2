using UnityEngine;
using System.Collections;

public class FlameScript : MonoBehaviour {

    public float bulletSpeed = 400f;
    public int flameLife = 0;
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
        ++flameLife;
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
		transform.Translate(Vector3.up * Random.Range(-1f,1f) * Time.deltaTime);
        if(flameLife == 80)
        {
            Destroy(gameObject);
        }
		objectAlpha = objectAlpha - .012f;
		spriteRendererName.color = new Color(1f, 1f, 1f, objectAlpha);
    }

    /*void OnCollisionEnter(Collision collision)
    {
        print("destroying bullet");
        Destroy(gameObject);
    }*/
}
