using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OptionsPanel;
    public GameObject CreditsPanel;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    // void Update() 
    // { 
    //     if (Input.GetKeyUp(KeyCode.Escape)) { OpenPauseMenu(); }
    // }
    public void StartGame() { SceneManager.LoadScene("Game"); }
    public void ToMainMenu() { SceneManager.LoadScene("MainMenu"); }
    public void TimeScale0() { Time.timeScale = 0.0f; }
    public void TimeScale1() { Time.timeScale = 1.0f; }
    public void OpenCredits() {
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(true);
            Panel.SetActive(false);
        }
    }
    public void CloseCredits() {
        if (Panel != null)  {
            CreditsPanel.SetActive(false);
            Panel.SetActive(true);
        }
    }
    public void OpenOptions() {
        if (OptionsPanel != null)
        {
            OptionsPanel.SetActive(true);
            Panel.SetActive(false);
        }
    }
    public void CloseOptions() {
        if (Panel != null)
        {
            OptionsPanel.SetActive(false);
            Panel.SetActive(true);
        }
    }
    public void OpenPauseMenu() { 
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false); 
    }
    public void ClosePauseMenu() { 
        PauseMenu.SetActive(false); 
        PauseButton.SetActive(true); 
    }
    public void QuitBtn() { Application.Quit(); }
}
