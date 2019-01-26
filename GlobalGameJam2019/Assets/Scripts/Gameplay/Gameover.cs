using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour {

    public GameObject m_gameoverUI;
    public GameManager m_gameManager = null;
    // Use this for initialization
    void Start()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void gameover()
    {
        m_gameManager.m_endGame = true;
        m_gameoverUI.SetActive(true);
    }


    public void quit()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
