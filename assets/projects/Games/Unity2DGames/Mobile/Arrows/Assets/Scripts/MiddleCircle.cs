using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCircle : MonoBehaviour
{
    public Sprite[] images;

    public SpriteRenderer spriteRendererCircle;

    void Start()
    {
        spriteRendererCircle = GetComponent<SpriteRenderer>();

        // Load the first image in the array as the initial sprite
        spriteRendererCircle.sprite = images[0];
    }
}
