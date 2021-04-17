using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicGet : MonoBehaviour
{
    public GameObject g_Menu;

    public KeyCode k_Menu = KeyCode.Escape;

    public AudioMixer audioMixer;

    private bool b_Menu = false;

    // Start is called before the first frame update
    void Start()
    {
        Class_Scene cs_Scene = new Class_Scene();
        float Volumn = cs_Scene.Get_PlayerPrefs_Float("Volumn");
        audioMixer.SetFloat("volume", Volumn);
    }

    private void Update()
    {
        if (Input.GetKeyDown(k_Menu))
        {
            b_Menu = !b_Menu;

            g_Menu.SetActive(b_Menu);

            if(b_Menu == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public string s_SceneMenu = "";

    public void Button_BackMenu()
    {
        Class_Scene cs_Scen = new Class_Scene(s_SceneMenu);
    }
}
