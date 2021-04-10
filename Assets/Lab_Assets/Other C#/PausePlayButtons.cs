using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePlayButtons : MonoBehaviour
{
    public bool pause;
    public bool play;

    public GameObject bird;

   /*  hint: setactive in each gameobject when it is false, it will make 
    *  disappear in the screen and true will make them show on the screen*/

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        play = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPause()
    {
        pause = true;
        play = false;
        if(pause)
        {
            Time.timeScale = 0.0f;
        }
    }

    public void onPlay()
    {
        play = true;
        pause = false;
        if(play)
        {
            Time.timeScale = 1.0f;
        }
    }

    public void GoBackMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnBirdVisible(bool hide)
    {
       bird.SetActive(hide);
    }
}
