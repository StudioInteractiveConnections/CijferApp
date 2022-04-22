using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject gameoverScreen;
    private GameObject guardOb;
    private Guard guard;
    private bool cap;

    void Start()
    {
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
}
