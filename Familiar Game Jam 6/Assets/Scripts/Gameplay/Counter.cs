using Extensions.System.Numeric;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Atributos
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Controles
    public Text counterText;
    
    // Valores
    private int counterValue = 0;
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Propiedades
    // ---- ---- ---- ---- ---- ---- ---- ----
    public int CounterValue
    {
        get { return this.counterValue; }
        set
        {
            this.counterValue = value.ClampToPositive();
            this.UpdateTextControl();
        }
    }
    
    public bool IsZero
    {
        get { return this.counterValue == 0; }
    }
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Métodos
    // ---- ---- ---- ---- ---- ---- ---- ----
    private void UpdateTextControl()
    {
        if (this.counterText != null)
            this.counterText.text = this.counterValue.ToString();
    }
    
}