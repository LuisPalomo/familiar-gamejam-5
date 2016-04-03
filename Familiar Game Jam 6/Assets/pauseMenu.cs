using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

    bool isPause = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
             if (isPause) {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } else {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Main Menu"))
        {
            SceneManager.LoadScene(0);
        }
            

    }

    void OnGUI()
    {
        Rect MainMenu = new Rect(Screen.width / 2, Screen.height / 2, 120, 50);
        if (isPause)
            GUI.Window(0, MainMenu, DoMyWindow, "Pause Menu");
    }
}
