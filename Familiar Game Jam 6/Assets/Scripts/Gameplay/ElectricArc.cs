using System;
using UnityEngine;

public class ElectricArc : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    
    public Sprite animationSprite0;
    public Sprite animationSprite1;

    public float animationTime = 0.1f;

    private float animationTimeCounter = 0.0f;

    private void Update()
    {
        this.animationTimeCounter += Time.deltaTime;
        if (this.animationTimeCounter > this.animationTime)
        {
            this.animationTimeCounter -= this.animationTime;
            if (this.spriteRenderer.sprite == this.animationSprite0)
                this.spriteRenderer.sprite = this.animationSprite1;
            else
                this.spriteRenderer.sprite = this.animationSprite0;
        }
    }
}
