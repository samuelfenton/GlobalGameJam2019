using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    [SerializeField]
    private int scenestart;

    [SerializeField]
    private int scenecredits;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartOnClick()
    {
        SceneManager.LoadScene(scenestart);
    }

    public void CreditsOnClick()
    {
        SceneManager.LoadScene(scenecredits);
    }

    public void quitOnClick()
    {
        Application.Quit();
    }
}
