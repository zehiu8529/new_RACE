using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string s_SceneMenu = "";
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public String s_ScenePlay = "_AnimalCube";

    // Start is called before the first frame update
    public void playgame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Class_Scene cs_Scene = new Class_Scene();
        float f_Volumn = 0;
        bool b_GetVolumn = audioMixer.GetFloat("volume", out f_Volumn);
        cs_Scene.Set_PlayerPrefs("Volumn", f_Volumn);
        cs_Scene.Set_ChanceScene(s_ScenePlay);

        //SceneManager.LoadScene(s_ScenePlay);
    }

    public void Quit()
    {
        // thoát cmn game luôn nhưng mà đây là demo thôi
        Application.Quit();
    }

    public void Button_BackMenu()
    {
        Class_Scene cs_Scen = new Class_Scene(s_SceneMenu);
    }
// Update is called once per frame
void Update()
    {

    }
}
