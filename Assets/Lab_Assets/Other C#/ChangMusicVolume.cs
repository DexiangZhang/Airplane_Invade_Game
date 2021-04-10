using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ChangMusicVolume : MonoBehaviour
{

    public Slider VolumeSlider;

    public Slider BGMusicSlider;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // save the change of volume equal to the slider value each time when we switch scene back and forth
        VolumeSlider.value = AudioListener.volume;
        BGMusicSlider.value = AudioListener.volume;
    }

    public void ChangeVol()
    {
        // make the value of slider corresponding to the volume of music
        AudioListener.volume = VolumeSlider.value;
        
    }

    public void ChangeBGVol()
    {
        AudioListener.volume = BGMusicSlider.value;
    }

    public void onMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
   
}
