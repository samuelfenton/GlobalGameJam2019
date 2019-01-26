using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kevin : MonoBehaviour {

    [SerializeField]
    private GameObject Kevin_Head;

    [SerializeField]
    private GameObject Kevin_Shrine;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Headkevin()
    {
        Kevin_Head.SetActive(true);
        Kevin_Shrine.SetActive(false);
    }
}
