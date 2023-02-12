using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;

    public static bool game = false;

    public TextMeshProUGUI scoretext;
    public GameObject canvas;
    
    //Save Variables
    private const string DIR_DATA = "/Data/"; //what directory will be called
    private const string FILE_HIGH_SCORE = "highScore.txt"; //file where info will be saved
    private string PATH_HIGH_SCORE;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            if (score > HighScore) 
            {
                HighScore = score;
            }
        }

    }

    private int highScore = 0;

    public int HighScore
    {
        get { return highScore; }
        set
        {
            highScore = value;
            File.WriteAllText(PATH_HIGH_SCORE, highScore.ToString());

            Directory.CreateDirectory(Application.dataPath + DIR_DATA); //creates directory if it does not exist
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PATH_HIGH_SCORE = Application.dataPath + DIR_DATA + FILE_HIGH_SCORE; //looks for where data can be stored in device
        //first looks for folder then file

        if (File.Exists(PATH_HIGH_SCORE))
        {
            HighScore = Int32.Parse(File.ReadAllText(PATH_HIGH_SCORE)); //will implement high score when game starts
            //parse turns integer into string
        }
    }
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (game == false && score == 4) //if the bool is false and score reaches 4
        {
            score = 0; //will reset score
            game = true; //will turn bool true
            SceneManager.LoadScene("Level 2"); //will load new scene
        }

        scoretext.text = "Score: " + score + "\n" +
                         "High Score:" + highScore; //make the text say the score and highscore
    }
}
