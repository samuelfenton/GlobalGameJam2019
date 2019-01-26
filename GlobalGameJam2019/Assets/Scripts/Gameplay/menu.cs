using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void StartOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsOnClick()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void quitOnClick()
    {
        Application.Quit();
    }
}
