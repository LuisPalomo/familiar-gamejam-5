using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GetSliderValue : MonoBehaviour
{
    public Slider slider;
    public Text text;

    private void Update()
    {
        this.text.text = string.Format("{0:0.0}", slider.value);
    }

}