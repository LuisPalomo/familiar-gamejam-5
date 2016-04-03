using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Prefab("Game manager", true)]
public sealed class GameManager : Singleton<GameManager>
{
    // ---- ---- ---- ---- ---- ---- ---- ----
    // Atributos
    // ---- ---- ---- ---- ---- ---- ---- ----
    public GameOverCanvasController gameOverScreen;

    String nameScene;
    public int lives;
    public int coins = 0;
    // Lenguaje
    private string gameLanguage;
    
    // Datos guardados del juego
    private GamePersistentData gamePersistentData;

    private bool gameOverShown = false;

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
        if (nameScene.Equals("AlphaGameplay"))
        {

        }

        if (nameScene.Equals("MainMenu"))
        {
            lives = 3;
            gameOverShown = false;

            Time.timeScale = 1.0f;
        }
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
        GameManager.Instance.LoadData();
        Localization.Initialize();
    }

    void Start()
    {
        String nameScene = SceneManager.GetActiveScene().name;

    }

    void Update()
    {
        if (lives <= 0 && (!gameOverShown))
        {
            GameOverCanvasController gos = GameObject.Instantiate<GameOverCanvasController>(this.gameOverScreen);
            gos.transform.position = new Vector3(0.0f, 0.0f, -0.5f);
            gos.Show();

            gameOverShown = true;

            Time.timeScale = 0.0f;
            StartCoroutine(ReturnToMainInSeconds(5.0f));
        }
    }

    private IEnumerator ReturnToMainInSeconds(float p)
    {
        float time = 0.0f;
        while (time < p)
        {
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        ReturnToMainMenu();
    }

    protected override void OnDestroy()
    {
        GameManager.Instance.SaveData();
        base.OnDestroy();
    }
    
	public void LevelFinish(){
		if (nameScene == "level1-Tuto") {
			SceneManager.LoadScene ("Level-LMGG");
		}
		else if (nameScene == "Level-LMGG") {
			SceneManager.LoadScene ("level3 - whereIs");
		}
		//else if (nameScene == "level3 - whereIs") {
		//	SceneManager.LoadScene ("fin");
		//}

	}

    public void ReturnToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("MainMenu");
    }

}