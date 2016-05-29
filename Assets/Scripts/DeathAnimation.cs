using UnityEngine;
using System.Collections;

public class DeathAnimation : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    public Rigidbody2D rigbod;
    public Sprite[] sprites;
    public int spriteGap;

    int frameCount = 0;
    int frameIndex = -1;
    bool animating;

    // Use this for initialization
    void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigbod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (!LevelManager.isPaused() && animating)
        {
            frameCount++;
            if (frameCount == spriteGap)
            {
                frameIndex++;
                if (frameIndex >= sprites.Length)
                {
                    if (!CompareTag("Player")) Destroy(gameObject);
                    return;
                }
                Sprite newSprite = sprites[frameIndex];
                float newY = (spriteRenderer.sprite.bounds.size.y - newSprite.bounds.size.y) / 2;
                Vector3 position = transform.position;
                position.y -= newY;
                transform.position = position;
                spriteRenderer.sprite = newSprite;
                frameCount = 0;
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        animating = true;
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(rigbod);
    }
}
