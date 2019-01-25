using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour {

    //current highscore
    float fCurrentScore = 0.0f;
    //current name of player
    string szPlayerName = "tst";

    //file location
    string szScoreTextFile = "Assets/Scripts/Gameplay/scores.txt";

    //Game Manager reference
    public GameManager g;

    void Awake()
    {
        saveScore();
    }

    void Update ()
    {
        fCurrentScore = g.nAlcoholBottles;
	}

    //saves the score into a notepad fle
    void saveScore()
    {
        StreamWriter write = new StreamWriter(szScoreTextFile, true);
        write.WriteLine(szPlayerName + ": " + fCurrentScore.ToString());
        write.Close();
    }
}
