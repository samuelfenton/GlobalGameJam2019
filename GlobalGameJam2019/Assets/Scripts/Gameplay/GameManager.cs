using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //alcohol bottle counter
    public int nAlcoholBottles = 0;


    public float[] effectPercentages = new float[(int)Player.DRUNK_EFFECTS.EFFECT_COUNT];

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
        //initialising base variables
        for (int i = 0; i < (int)Player.DRUNK_EFFECTS.EFFECT_COUNT; i++)
        {
            currentDrunkenness[i] = false;
        }
        

        switch (nAlcoholBottles)
        {
            case 1:
                {
                    currentDrunkenness = temp(currentDrunkenness, 10.0f);
                }
                break;
            case 2:
                {
                    currentDrunkenness = temp(currentDrunkenness, 20.0f);
                }
                break;
            case 3:
                {
                    currentDrunkenness = temp(currentDrunkenness, 30.0f);
                }
                break;
            case 4:
                {
                    currentDrunkenness = temp(currentDrunkenness, 40.0f);
                }
                break;
            case 5:
                {
                    currentDrunkenness = temp(currentDrunkenness, 50.0f);
                }
                break;
            case 6:
                {
                    currentDrunkenness = temp(currentDrunkenness, 60.0f);
                }
                break;
            case 7:
                {
                    currentDrunkenness = temp(currentDrunkenness, 70.0f);
                }
                break;
            case 8:
                {
                    currentDrunkenness = temp(currentDrunkenness, 80.0f);
                }
                break;
            case 9:
                {
                    currentDrunkenness = temp(currentDrunkenness, 90.0f);
                }
                break;
            default:
                {
                    currentDrunkenness = temp(currentDrunkenness, 100.0f);
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

    public bool[] temp(bool[] p_currentDrunkenness, float num)
    {
        if (Random.Range(0, 100) <= num)
        {
            int randNum = Random.Range(0, 100);
            for(int i = 0; i < (int)Player.DRUNK_EFFECTS.EFFECT_COUNT; i++)
            {
                if (i != (int)Player.DRUNK_EFFECTS.FLIP_VERT_INPUT)
                {
                    if(effectPercentages[(int)(i)] <= randNum && randNum > effectPercentages[(int)(i - 1)])
                    {
                        p_currentDrunkenness[i] = true;
                    }
                }
                else
                {
                    if (effectPercentages[(int)(i)] < randNum)
                    {
                        p_currentDrunkenness[i] = true;
                    }
                }
            }

        }

        return p_currentDrunkenness;
    }
}
