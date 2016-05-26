using UnityEngine;
using System.Collections;

public class DeathAnimation : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public int spriteGap;

    int frameCount = 0;
    int frameIndex = -1;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        frameCount++;
        if (frameCount == spriteGap)
        {
            frameIndex++;
            if (frameIndex >= sprites.Length)
            {
                if (!CompareTag("Player")) Destroy(gameObject);
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
