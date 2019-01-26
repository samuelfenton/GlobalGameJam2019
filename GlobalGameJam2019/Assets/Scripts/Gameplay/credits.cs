using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour {

    [SerializeField]
    private GameObject text;

    [SerializeField]
    private float speed = 2;

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
        text.transform.position += new Vector3(0, speed, 0);

        if (timel >= TimeEnd)
        {
            SceneManager.LoadScene(menuScene);
        }
	}
}
