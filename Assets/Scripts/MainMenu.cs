using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject StartPanel;
    public GameObject OptionsPanel;
    public GameObject CreditsPanel;

    public void OpenStart()
    {
        if (StartPanel != null)
        {
            StartPanel.SetActive(true);
            Panel.SetActive(false);
        }
    }

    public void CloseStart()
    {
        if (Panel != null)
        {
            StartPanel.SetActive(false);
            Panel.SetActive(true);
        }
    }
    
    public void OpenOptions()
    {
        if (OptionsPanel != null)
        {
            OptionsPanel.SetActive(true);
            Panel.SetActive(false);
        }
    }

    public void CloseOptions()
    {
        if (Panel != null)
        {
            OptionsPanel.SetActive(false);
            Panel.SetActive(true);
        }
    }

    public void OpenCredits()
    {
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(true);
            Panel.SetActive(false);
        }
    }

    public void CloseCredits()
    {
        if (Panel != null)
        {
            CreditsPanel.SetActive(false);
            Panel.SetActive(true);
        }
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
