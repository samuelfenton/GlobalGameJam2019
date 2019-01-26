using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //alcohol bottle counter
    public int nAlcoholBottles = 0;

    public float AlcoholStrength = 0;

    public float[] effectPercentages = new float[(int)Player.DRUNK_EFFECTS.EFFECT_COUNT];

    public int AmountOFEffects = 3;

    public bool testingMode = false;

    //player reference
    public Transform tPlayerPosition;

    //awake
    void Awake()
    {
        //initialising the alcohol count
        nAlcoholBottles = 0;
        if (testingMode == true)
            nAlcoholBottles = 7;

        tPlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Cancel") != 0.0f)
            Application.Quit();
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

        AlcoholStrength = (Mathf.Pow((nAlcoholBottles), 2)) - 1;

        float percentage = AlcoholStrength;
        if (percentage > 100)
            percentage = 100;

        currentDrunkenness = PlayerEffectedCalc(currentDrunkenness, percentage);

        return currentDrunkenness;
    }
    //the current effect

    public bool[] PlayerEffectedCalc(bool[] p_currentDrunkenness, float num)
    {
        //randomly geenrates 3 numebers
        int[] nRandGenNumber = new int[AmountOFEffects];
        for(int j = 0; j < AmountOFEffects; j++)
        {
            nRandGenNumber[j] = Random.Range(0, 100);
        }

        for (int j = 0; j < AmountOFEffects; j++)
        {
            if (nRandGenNumber[j] <= num)
            {
                int randNum = Random.Range(0, 100);
                for (int i = 0; i < (int)Player.DRUNK_EFFECTS.EFFECT_COUNT; i++)
                {
                    if (i != (int)Player.DRUNK_EFFECTS.EFFECT_COUNT - 1)
                    {
                        if (effectPercentages[(int)(i)] <= randNum && randNum < effectPercentages[(int)(i + 1)])
                        {
                            p_currentDrunkenness[i] = true;
                            break;
                        }
                    }
                    else
                    {
                        if (effectPercentages[(int)(i)] <= randNum && effectPercentages[(int)(i)] < 100)
                        {
                            p_currentDrunkenness[i] = true;
                            break;
                        }
                    }
                }

            }
        }
        return p_currentDrunkenness;
    }
}
