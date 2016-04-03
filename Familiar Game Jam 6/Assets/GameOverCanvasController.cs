using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvasController : MonoBehaviour
{
    public Transform gameOverText;
    public Image returnButton;
    public Text returnText;

    public float fadeTime = 0.5f;
    public float gameOverShowTime = 1.5f;
    public AnimationCurve gameOverRotation = new AnimationCurve();
    public AnimationCurve gameOverScale = new AnimationCurve();

    private CanvasGroup canvasGroup;


    public void Awake()
    {
        this.canvasGroup = this.GetComponent<CanvasGroup>();

        this.canvasGroup.alpha = 0.0f;
        this.canvasGroup.interactable = false;
        this.canvasGroup.blocksRaycasts = false;

        this.gameOverText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        this.returnButton.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        this.returnText.color = new Color(0.125f, 0.125f, 0.125f, 0.0f);

        this.Show();
    }

    public void Show()
    {
        this.StartCoroutine(this.ShowAnimation());
    }

    private IEnumerator ShowAnimation()
    {
        float normalizedTime, inverseTotalTime;

        normalizedTime = 0.0f;
        inverseTotalTime = 1.0f / this.fadeTime;
        while (normalizedTime < 1.0f)
        {
            this.canvasGroup.alpha = normalizedTime;
            
            normalizedTime += Time.deltaTime * inverseTotalTime;
            yield return null;
        }

        this.canvasGroup.alpha = 1.0f;
        this.canvasGroup.interactable = true;
        this.canvasGroup.blocksRaycasts = true;

        // Rotar game over
        this.gameOverText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        normalizedTime = 0.0f;
        inverseTotalTime = 1.0f / this.gameOverShowTime;
        while (normalizedTime < 1.0f)
        {
            this.gameOverText.rotation = Quaternion.AngleAxis(this.gameOverRotation.Evaluate(normalizedTime), Vector3.back);
            this.gameOverText.localScale = Vector3.one * this.gameOverScale.Evaluate(normalizedTime);

            normalizedTime += Time.deltaTime * inverseTotalTime;
            yield return null;
        }

        this.gameOverText.rotation = Quaternion.AngleAxis(this.gameOverRotation.Evaluate(1.0f), Vector3.back);
        this.gameOverText.localScale = Vector3.one * this.gameOverScale.Evaluate(1.0f);

        // Show button
        normalizedTime = 0.0f;
        inverseTotalTime = 1.0f / this.gameOverShowTime;
        while (normalizedTime < 1.0f)
        {
            this.returnButton.color = new Color(1.0f, 1.0f, 1.0f, normalizedTime);
            this.returnText.color = new Color(0.125f, 0.125f, 0.125f, normalizedTime);
            
            normalizedTime += Time.deltaTime * inverseTotalTime;
            yield return null;
        }

        this.returnButton.color = Color.white;
        this.returnText.color = new Color(0.125f, 0.125f, 0.125f, 1.0f);
            
    }

}