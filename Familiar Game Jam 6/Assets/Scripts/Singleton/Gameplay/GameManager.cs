using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Prefab("Game manager", true)]
public sealed class GameManager : Singleton<GameManager>
{
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Atributos

    String nameScene;
    public int lives;
    public int coins = 0;
    // Lenguaje
    private string gameLanguage;
    
    // Datos guardados del juego
    private GamePersistentData gamePersistentData;
    
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Propiedades
    // ---- ---- ---- ---- ---- ---- ---- ----
    public string GameLanguage
    {
        get { return GameManager.Instance.gameLanguage; }
        set
        {
            if (GameManager.Instance.gameLanguage != value)
            {
                GameManager.Instance.gameLanguage = value;
                GameManager.Instance.OnGameLanguageChanged(value);
            }
        }
    }
    
    public GamePersistentData GamePersistentData
    {
        get { return GameManager.Instance.gamePersistentData; }
    }
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Eventos
    // ---- ---- ---- ---- ---- ---- ---- ----
    public event Action<string> OnGameLanguageChanged = delegate { };

    

    void OnLevelWasLoaded(int level)
    {
        nameScene = SceneManager.GetSceneAt(level).name;
        

    }

    // ---- ---- ---- ---- ---- ---- ---- ----
    // Métodos
    // ---- ---- ---- ---- ---- ---- ---- ----

    // Métodos de control
    public void ExitApplication()
    {
        #if UNITY_EDITOR
            Debug.Log("Salida de la aplicación recibida.");
        #endif
        
        Application.Quit();
    }
    
    // Métodos de guardado y carga de datos
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public void LoadData()
    {
        // Cargar datos persistentes del juego
        if (PlayerPrefs.HasKey("GamePersistentData"))
        {
            string persistentData = PlayerPrefs.GetString("GamePersistentData");
            GameManager.Instance.gamePersistentData = JsonUtility.FromJson<GamePersistentData>(persistentData);
        }
        else
        {
            GameManager.Instance.gamePersistentData = new GamePersistentData();
        }
        
        // Cargar idioma actual del juego
        if (PlayerPrefs.HasKey("Language"))
            GameManager.Instance.gameLanguage = PlayerPrefs.GetString("Language");
        else
            GameManager.Instance.gameLanguage = "es";
    }
    
    public void SaveData()
    {
        // Guardar datos persistentes del juego
        string serializedData = JsonUtility.ToJson(GameManager.Instance.gamePersistentData);
        PlayerPrefs.SetString("GamePersistentData", serializedData);
        
        // Guardar idioma actual del juego
        PlayerPrefs.SetString("Language", GameManager.Instance.gameLanguage);
    }
    
    // Métodos de Monobehaviour
    private void Awake()
    {
        
    }

    void Start()
    {
        String nameScene = SceneManager.GetActiveScene().name;

    }

    void Update()
    {

    }

    protected override void OnDestroy()
    {
       
        base.OnDestroy();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}