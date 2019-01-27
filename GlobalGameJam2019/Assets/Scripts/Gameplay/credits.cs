using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour {

    [SerializeField]
    private int menuScene;

    [SerializeField]
    private float TimeEnd;

    private float timel = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timel += Time.deltaTime;
        if (timel >= TimeEnd)
        {
            SceneManager.LoadScene(menuScene);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(menuScene);
        }
	}
}
