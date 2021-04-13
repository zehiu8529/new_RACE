using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCube_GetWay : MonoBehaviour
{
    private CheckPoint3D_Get cs_Way;

    public Text t_MessageRonWay;

    private void Start()
    {
        cs_Way = GetComponent<CheckPoint3D_Get>();
    }

    private void Update()
    {
        if (cs_Way.Get_RonWay(cs_Way.f_DegCheck))
        {
            t_MessageRonWay.text = "RON WAY!";
        }
        else
        {
            t_MessageRonWay.text = "";
        }
    }
}
