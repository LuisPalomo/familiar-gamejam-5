using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class AutoLocalizingText : MonoBehaviour
{
    private void Awake()
    {
        string currentLangauge = GameManager.Instance.GameLanguage;
        
        Text text = this.GetComponent<Text>();
        if (text != null)
            text.text = Localization.GetString(currentLangauge, text.text);
    }
    
}