﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour {

    //reference to self gameobject
    private GameObject bottle;

    //collected or not
    public bool bCollected = false;

	void Awake ()
    {
        bottle = this.gameObject;
        bottle.SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(bCollected == true)
        {
            bottle.SetActive(false);
        }	
	}
}