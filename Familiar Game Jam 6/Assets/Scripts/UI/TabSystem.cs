using System;
using UnityEngine;

public class TabSystem : MonoBehaviour
{
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Atributos
    // ---- ---- ---- ---- ---- ---- ---- ----
    private int activeTab = 0;
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Eventos
    // ---- ---- ---- ---- ---- ---- ---- ----
    public event Action<int> OnTabChange = delegate { };
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Métodos
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Métodos de MonoBehaviour
    private void Awake()
    {
        this.SetActiveTab(this.activeTab);
    }
    
    // Métodos de control
    public void SetActiveTab(int tabNumber)
    {
        if (tabNumber != this.activeTab)
        {
            // Desactivar todas las fichas y activar solo la seleccionada
            for (int i = 0; i < this.transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.gameObject.SetActive(false);
            }
            this.transform.GetChild(tabNumber).gameObject.SetActive(true);
            
            // Asignar ficha actual
            this.activeTab = tabNumber;
            
            // Lanzar evento
            this.OnTabChange(tabNumber);
        }
    }
    
}