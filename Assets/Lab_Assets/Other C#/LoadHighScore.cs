using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadHighScore : MonoBehaviour
{
    public Text[] scoreTexts;

    const int NUM_HIGH_SCORES = 5;

    public const string SCORE_KEY = "HSScore";
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            scoreTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY + i).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
