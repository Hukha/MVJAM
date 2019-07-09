using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public float Fruits = 0;
    public float Shoots = 0;
    public GameObject completeLevelUI;
    public bool GamePause = false;
    public bool WinActive = false;
    public bool LoseActive = false;
    public GameObject PauseMenuUI;
    public GameObject UIGeneral;
    public GameObject LoseUI;
    public Text ScoreText;

	void LevelWon () {
        UIGeneral.SetActive(false);
        completeLevelUI.SetActive(true);
        WinActive = true;
        Time.timeScale = 0;
    }
    void LevelLose() {
        UIGeneral.SetActive(false);
        LoseUI.SetActive(true);
        LoseActive = true;
        Time.timeScale = 0;
    }
    public void Shooting() {
        Shoots--;
        if (Shoots <= 0) {
            LevelLose();
        }
    }
    public void CatchFruit() {
        Fruits++;
        if (Fruits == 5) {
            LevelWon();
        }
    }
    void Update() {
        ScoreText.text = Shoots.ToString();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GamePause) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GamePause = false;
    }
    public void MenuButton()
    {
        Debug.Log("Menu Button pres...");
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        //Cargar Menu/Scene, añadir scenemanager
        //Añadir tambien volver tiempo a la normalidad
    }
    public void QuitButton() {
        Debug.Log("Quit Button pres...");
        Application.Quit();
    }
    void Pause() {
        if (WinActive == false && LoseActive == false) { 
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GamePause = true;
    }
    }
    public void Restart() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
