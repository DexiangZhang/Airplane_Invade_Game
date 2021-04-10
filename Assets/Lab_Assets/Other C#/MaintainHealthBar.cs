using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaintainHealthBar : MonoBehaviour
{

    // Start is called before the first frame update
    public static MaintainHealthBar Instance;
    void Awake()
    {

        if (Instance == null)
        {

            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        // index 0 is menu scene and index 3 is ending scene
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 3 )
        {
            Destroy(this.gameObject);
        }
      
    }

}
