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
    public float spriteGap = 0;
    public int animationIndex = 0;
    public int staticIndex = 0;
    public bool animating = false;

    [System.NonSerialized]
    public float spriteTime = 0;
    [System.NonSerialized]
    public int frameIndex = 0;


	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer
        spriteRenderer.sprite = staticSprites[staticIndex]; // set the sprite to baseSprite
    }

    void updateChildren(Sprite newSprite)
    {
        foreach(MatchParentAnimation child in GetComponentsInChildren<MatchParentAnimation>())
        {
            child.NewSprite(newSprite);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!LevelManager.isPaused())
        {
            if (animating)
            {
                spriteTime += Time.deltaTime;
                if (spriteTime >= spriteGap)
                {
                    frameIndex++;
                    if (frameIndex >= animatedSprites[animationIndex].sprites.Length)
                    {
                        frameIndex = 0;
                    }
                    Sprite newSprite = animatedSprites[animationIndex].sprites[frameIndex];
                    spriteRenderer.sprite = newSprite;
                    updateChildren(newSprite);
                    spriteTime = 0;
                }
            }
            else
            {
                spriteTime = 0;
                animationIndex = 0;
                spriteRenderer.sprite = staticSprites[staticIndex];
                updateChildren(staticSprites[staticIndex]);
            }
        }
    }
}
