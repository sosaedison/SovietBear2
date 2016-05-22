using UnityEngine;
using System.Collections;

public class MatchParentAnimation : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void NewSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
