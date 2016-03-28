using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Atributos
    // ---- ---- ---- ---- ---- ---- ---- ----
    public Text timerText;
    
    private bool running = false;
    private float time = 0.0f;
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Eventos
    // ---- ---- ---- ---- ---- ---- ---- ----
    /// <summary>
    /// Ocurre cuando el temporizador ha llegado a cero.
    /// </summary>
    public event Action OnTimerEnded = delegate { };
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Métodos
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Métodos de control
    public void StartTimer(float timeLimit)
    {
        if (timeLimit > 0.0f)
        {
            this.running = true;
            this.time = timeLimit;
        }
    }
    
    public void PauseTimer()
    {
        this.running = false;
    }
    
    public void ResumeTimer()
    {
        this.running = true;
    }
    
    // Métodos de MonoBehaviour
    private void Update()
    {
        if (this.running)
        {
            // Actualizar tiempo
            this.time -= Time.deltaTime;
            
            // Actualizar texto
            this.timerText.text = string.Format("{0:0}''", this.time);
            
            // Lanzar evento al finalizar
            if (this.time < 0.0f)
            {
                this.running = false;
                this.time = 0.0f;
                this.OnTimerEnded();
            }
        }
    }
    
}