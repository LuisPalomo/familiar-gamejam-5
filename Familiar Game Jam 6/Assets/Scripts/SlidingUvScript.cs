using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class SlidingUvScript : MonoBehaviour
{
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Atributos
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Públicos
    public float xSpeed = 0.0f;
    public float ySpeed = 0.0f;

    public float xTiling = 1.0f;
    public float yTiling = 1.0f;

    public bool autoWidth = false;

    // Privados
    private RawImage rawImage;

    // ---- ---- ---- ---- ---- ---- ---- ----
    // Métodos
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Métodos de MonoBehaviour
    private void Awake()
    {
        this.rawImage = this.GetComponent<RawImage>();

        if (autoWidth)
        {
            RectTransform rectTransform = this.GetComponent<RectTransform>();

            float imageRatio = rectTransform.rect.width / rectTransform.rect.height;
            this.xTiling = this.yTiling * imageRatio;
        }
    }
	
    private void Update()
    {
        float newX = Mathf.Repeat(this.rawImage.uvRect.x + Time.deltaTime * this.xSpeed, 1.0f);
        float newY = Mathf.Repeat(this.rawImage.uvRect.y + Time.deltaTime * this.ySpeed, 1.0f);

        this.rawImage.uvRect = new Rect(newX, newY, this.xTiling, this.yTiling);
    }

}
