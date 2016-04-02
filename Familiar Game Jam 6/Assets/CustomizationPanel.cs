using System;
using UnityEngine;
using System.Collections;

public enum Gender { Male, Female };

public class CustomizationPanel : MonoBehaviour
{
    public GameObject loadingIndicator;

    public bool IsMale { get; set; }
    public float Height { get; set; }
    public float Weight { get; set; }
    public int ColorIndex { get; set; }

    public void SetGender(bool isMale)
    {
        this.IsMale = isMale;
        this.ShowLoading();
    }

    public void SetHeight(float height)
    {
        this.Height = height;
        this.ShowLoading();
    }

    public void SetWeight(float weight)
    {
        this.Weight = weight;
        this.ShowLoading();
    }

    public void SetColorIndex(int colorIndex)
    {
        this.ColorIndex = ColorIndex;
        this.ShowLoading();
    }

    private void ShowLoading()
    {
        this.loadingIndicator.SetActive(false);
        this.StopAllCoroutines();
        this.StartCoroutine(this.ShowIndicator());
    }

    private IEnumerator ShowIndicator()
    {
        this.loadingIndicator.SetActive(true);
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.25f, 1.0f));
        this.loadingIndicator.SetActive(false);
    }

}