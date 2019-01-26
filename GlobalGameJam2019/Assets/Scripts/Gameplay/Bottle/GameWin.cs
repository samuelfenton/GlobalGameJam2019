using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject gWinScreenObject;
    public GameObject bButton;
    public ScoreManager sMan;
    public Button bSubmitDisable;

    public bool lastLevel = false;

    public void Win()
    {
        gWinScreenObject.SetActive(true);
        if(lastLevel == false)
        {
            //hide button
            bButton.SetActive(false);
        }
    }

    public void quit()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void setPlayerName()
    {
        sMan.storeName(sMan.input.text);
        sMan.setName();
        bSubmitDisable.gameObject.SetActive(false);
    }
}
