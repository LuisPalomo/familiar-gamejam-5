using UnityEngine;
using System.Collections;

public class CursorAutoScaler : MonoBehaviour
{
    public float sizeFactor = 5.0f;

    private int currentHeight;
    private int currentWidth;

    private void Awake()
    {
        this.currentHeight = Screen.height;
        this.currentHeight = Screen.width;
    }

    private void Update()
    {
        if (this.currentHeight != Screen.height)
        {
            this.currentHeight = Screen.height;
            this.transform.localScale = (Vector2.one * this.sizeFactor) / this.currentHeight;
        }
    }

}