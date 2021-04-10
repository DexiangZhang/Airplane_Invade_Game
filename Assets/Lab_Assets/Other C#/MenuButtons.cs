using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlay()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void LoadInstruction()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ViewScores()
    {
        SceneManager.LoadScene("ViewHighScores");
    }
}
