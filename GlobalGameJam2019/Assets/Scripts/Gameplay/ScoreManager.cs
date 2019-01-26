using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour {

    //current highscore
    public float fCurrentScore = 0.0f;
    //current name of player
    public string szPlayerName = "tst";

    //file location
    [Tooltip("This is the string file location for the .txt file that is being written into.")]
    public string szScoreTextFile = "Assets/Scripts/Gameplay/scores.txt";

    //temp string
    private string szTemp;

    //event listener
    public TMP_InputField input;

    //display score
    public TextMeshProUGUI scoreCount;

    //Game Manager reference
    public GameManager g;

    void Awake()
    {
        //saveScore();
        //add listener
        var subEvent = new TMP_InputField.SubmitEvent();
        subEvent.AddListener(storeName);

        if(input!=null)
            input.onEndEdit = subEvent;

        scoreCount.text = fCurrentScore.ToString();

        g = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Update ()
    {
        fCurrentScore = g.nAlcoholBottles;
        scoreCount.text = (fCurrentScore * 100).ToString();
    }

    //saves the score into a notepad fle
    void saveScore()
    {
        StreamWriter write = new StreamWriter(szScoreTextFile, true);
        write.WriteLine(szPlayerName + ": " + (fCurrentScore * 100).ToString());
        write.Close();
    }

    public void storeName(string nm)
    {
        szTemp = nm;
    }

    public void setName()
    {
        szPlayerName = szTemp;
        saveScore();
    }
}
