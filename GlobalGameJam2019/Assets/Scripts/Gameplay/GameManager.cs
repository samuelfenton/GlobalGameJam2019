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

    public bool[] DetermineDrunkEffects()
    {
        bool[] currentDrunkenness = new bool[(int)Player.DRUNK_EFFECTS.EFFECT_COUNT];
        //Do magic here

        switch (nAlcoholBottles)
        {
            case 1:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 10.0f);
                }
                break;
            case 2:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 20.0f);
                }
                break;
            case 3:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 30.0f);
                }
                break;
            case 4:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 40.0f);
                }
                break;
            case 5:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 50.0f);
                }
                break;
            case 6:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 60.0f);
                }
                break;
            case 7:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 70.0f);
                }
                break;
            case 8:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 80.0f);
                }
                break;
            case 9:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 90.0f);
                }
                break;
            default:
                {
                    currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, 100.0f);
                }
                break;
        }
        return currentDrunkenness;
    }
    //the current effect
    public bool[] PlayerEffectedCalc(bool[] p_currentDrunkenness, float num)
    {
        if (Random.Range(0, 100) <= num)
        {
            int randNum = Random.Range(0, 100);
            if (randNum <= effectPercentages[0])
            {
                p_currentDrunkenness[(int)Player.DRUNK_EFFECTS.FLIP_VERT_INPUT] = true;
            }
            else if(randNum <= effectPercentages[1] && randNum > effectPercentages[0])
            {
                p_currentDrunkenness[(int)Player.DRUNK_EFFECTS.FLIP_HORI_INPUT] = true;
            }
        }

        return p_currentDrunkenness;
    }
}
