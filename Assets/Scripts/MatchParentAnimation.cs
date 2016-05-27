using UnityEngine;
using System.Collections;

public class MatchParentAnimation : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    public void NewSprite(Sprite sprite)
    {
        if (!spriteRenderer)
            spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}
