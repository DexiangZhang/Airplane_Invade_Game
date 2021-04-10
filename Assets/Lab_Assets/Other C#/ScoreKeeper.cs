using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{

    public Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
            scoreTxt.text = "Score : " + PersistentData.Instance.GetScore();
    }




}
