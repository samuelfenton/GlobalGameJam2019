using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //alcohol bottle counter
    public int nAlcoholBottles = 0;


    public float[] effectPercentages = new float[2];

    //player reference
    public Transform tPlayerPosition;

    //awake
    void Awake()
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

        switch (nAlcoholBottles)
        {
            case 1:
                {
                    currentDrunkenness = PlayerEffectedCalc(10.0f);
                }
                break;
            case 2:
                {
                    currentDrunkenness = PlayerEffectedCalc(20.0f);
                }
                break;
            case 3:
                {
                    currentDrunkenness = PlayerEffectedCalc(30.0f);
                }
                break;
            case 4:
                {
                    currentDrunkenness = PlayerEffectedCalc(40.0f);
                }
                break;
            case 5:
                {
                    currentDrunkenness = PlayerEffectedCalc(50.0f);
                }
                break;
            case 6:
                {
                    currentDrunkenness = PlayerEffectedCalc(60.0f);
                }
                break;
            case 7:
                {
                    currentDrunkenness = PlayerEffectedCalc(70.0f);
                }
                break;
            case 8:
                {
                    currentDrunkenness = PlayerEffectedCalc(80.0f);
                }
                break;
            case 9:
                {
                    currentDrunkenness = PlayerEffectedCalc(90.0f);
                }
                break;
            case 10:
                {
                    currentDrunkenness = PlayerEffectedCalc(100.0f);
                }
                break;
        }
        return currentDrunkenness;
    }
    //the current effect
    public Player.DrunkEffects PlayerEffectedCalc(float num)
    {
        Player.DrunkEffects currentEffect = new Player.DrunkEffects();

        if (Random.Range(0, 100) <= num)
        {
            int randNum = Random.Range(0, 100);
            if (randNum <= effectPercentages[0])
            {
                currentEffect.m_flipHorizontalInput = Player.DrunkEffects.ON_OFF.ON;
            }
            else if(randNum <= effectPercentages[1] && randNum > effectPercentages[0])
            {
                currentEffect.m_flipVerticalInput = Player.DrunkEffects.ON_OFF.ON;
            }
        }

        return currentEffect;
    }
}
