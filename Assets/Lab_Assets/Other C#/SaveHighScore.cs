using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveHighScore : MonoBehaviour
{

    public Text nameScoreText;

    public const int NUM_HIGH_SCORES = 5;

    public const string SCORE_KEY = "HSScore";
    // Start is called before the first frame update
    void Start()
    {
        int pScore = PersistentData.Instance.GetScore();
        nameScoreText.text = "Hello, Player" + " your score is " + pScore;
        SaveScores();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SaveScores()
    {
        int pScore = PersistentData.Instance.GetScore();

        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string curScoreKey = SCORE_KEY + i;


            if(!PlayerPrefs.HasKey(curScoreKey)) //no ith score stored yet
            {
                PlayerPrefs.SetInt(curScoreKey, pScore);
               
                Debug.Log("storing " + " as " + i + "th high score, score = " + pScore);

                return;
            }
            else
            {
                int score = PlayerPrefs.GetInt(curScoreKey);

                if (pScore >= score) //this score should replace previous ith highest -- note deliberations over equality
                {
                    int tempScore = score;
                    PlayerPrefs.SetInt(curScoreKey, pScore);
                    pScore = tempScore;
                }
            }
        }
    }

}
