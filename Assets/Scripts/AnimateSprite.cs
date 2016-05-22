using UnityEngine;
using System.Collections;

public class AnimateSprite : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    [System.Serializable]
    public class SpriteSet //because unity is dumb
    {
        public Sprite[] sprites;
    }
    public SpriteSet[] animatedSprites;
    public Sprite[] staticSprites;
    public int spriteGap = 0;
    public int animationIndex = 0;
    public int staticIndex = 0;
    public bool animating = false;

    private int frameCount = 0;
    private int frameIndex = 0;


	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer
        spriteRenderer.sprite = staticSprites[staticIndex]; // set the sprite to baseSprite
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (animating)
        {
            frameCount++;
            if (frameCount == spriteGap)
            {
                frameIndex++;
                if (frameIndex >= animatedSprites[animationIndex].sprites.Length)
                {
                    frameIndex = 0;
                }
                spriteRenderer.sprite = animatedSprites[animationIndex].sprites[frameIndex];
                frameCount = 0;
            }
        }
        else
        {
            frameCount = 0;
            animationIndex = 0;
            spriteRenderer.sprite = staticSprites[staticIndex];
        }
	}
}
