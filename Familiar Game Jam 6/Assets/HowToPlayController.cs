using UnityEngine;
using System.Collections;

public class HowToPlayController : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public float animTime = 1.0f;

    public void Hide()
    {
        this.StartCoroutine(this.MakeHide());
    }

    public void Show()
    {
        this.StartCoroutine(this.MakeShow());
    }

    private IEnumerator MakeHide()
    {
        float normalizedTime = 0.0f, inverseTotalTime = 1.0f / this.animTime;
        while (normalizedTime < 1.0f)
        {
            this.canvasGroup.alpha = 1.0f - normalizedTime;
            
            normalizedTime += Time.deltaTime * inverseTotalTime;
            yield return null;
        }
        
        this.canvasGroup.interactable = false;
        this.canvasGroup.blocksRaycasts = false;
        this.canvasGroup.alpha = 0.0f;
    }

    private IEnumerator MakeShow()
    {
        this.canvasGroup.interactable = true;
        this.canvasGroup.blocksRaycasts = true;

        float normalizedTime = 0.0f, inverseTotalTime = 1.0f / this.animTime;
        while (normalizedTime < 1.0f)
        {
            this.canvasGroup.alpha = normalizedTime;
            
            normalizedTime += Time.deltaTime * inverseTotalTime;
            yield return null;
        }
        
        this.canvasGroup.alpha = 1.0f;
    }

}