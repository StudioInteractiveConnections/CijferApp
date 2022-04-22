using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    private GameObject gameoverScreen;
    private GameObject guardOb;
    private Guard guard;
    private bool cap;

    void Start()
    {
        Time.timeScale = 1;
        cap = false;
        gameoverScreen = GameObject.Find("GameOver");
        guardOb = GameObject.FindGameObjectWithTag("Guard");
        guard = guardOb.GetComponent<Guard>();
        gameoverScreen.SetActive(false);
    }

    void Update()
    {
        Debug.Log("GAMEOVER");
        Debug.Log("cap is " + cap);
        cap = guard.GetArrest();

        if (cap)
        {
            gameoverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
