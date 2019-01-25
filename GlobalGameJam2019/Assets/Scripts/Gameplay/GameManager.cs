using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //alcohol bottle counter
    public int nAlcoholBottles = 0;

    //player reference
    public Transform tPlayerPosition;

    //awake
	void Awake ()
    {
        //initialising the alcohol count
        nAlcoholBottles = 0;
	}

    //counting
    public void AddCount()
    {
        nAlcoholBottles++;
    }

    public Player.DrunkEffects DetermineDrunkEffects()
    {
        Player.DrunkEffects currentDrunkenness = new Player.DrunkEffects();
        //Do magic here


        return currentDrunkenness;
    }
}
