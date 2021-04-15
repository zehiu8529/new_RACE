using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;




public class PlayGame : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {

        
        audioMixer.SetFloat("volume", volume);
    }

   
   
    // Start is called before the first frame update
    public void playgame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     
    }
 
    public void Quit()
    {
        // thoát cmn game luôn nhưng mà đây là demo thôi
        Application.Quit();
    }



  
    // Update is called once per frame
    void Update()
    {
        
    }
}
