using Extensions.System.Numeric;
using System;
using UnityEngine;

[Serializable]
public class GamePersistentData
{
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Atributos
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Estado
    [SerializeField]
    private int coins = 0;
    [SerializeField]
    private int experiencePoints = 0;
    
    // Estadísticas
    [SerializeField]
    private int totalKicks = 0;
    [SerializeField]
    private int totalGoals = 0;
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Propiedades
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Estado
    public int Coins
    {
        get { return this.coins; }
        set { this.coins = value.ClampToPositive(); }
    }
    
    public int ExperiencePoints
    {
        get { return this.experiencePoints; }
        set { this.experiencePoints = value.ClampToPositive(); }
    }
    
    // Estadísticas
    public int TotalKicks
    {
        get { return this.totalKicks; }
        set { this.totalKicks = value.ClampToPositive(); }
    }
    
    public int TotalGoals
    {
        get { return this.totalGoals; }
        set { this.totalGoals = value.ClampToPositive(); }
    }
    
    public float SuccessRate
    {
        get { return this.totalKicks > 0 ? ((float)this.totalGoals) / ((float)this.totalKicks) * 100.0f : 0.0f; }
    }
    
}