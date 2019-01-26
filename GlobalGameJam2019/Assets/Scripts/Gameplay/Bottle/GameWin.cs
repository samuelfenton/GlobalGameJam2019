using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject gWinScreenObject;
    public Button bButton;
    public ScoreManager sMan;
    public Button bSubmitDisable;

    public bool lastLevel = false;

    public void Start()
    {
        gWinScreenObject.SetActive(true);
        if(lastLevel == true)
        {
            //hide button
            bButton.interactable = false;
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
        bSubmitDisable.interactable = false;//.SetActive(false);
    }
}
