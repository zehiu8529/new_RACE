using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use with Camera set 'Orthographic' to make 2.5D Game on 3D Environment
/// </summary>
[ExecuteAlways]
public class Isometric_Single : MonoBehaviour
{
    //Notice: This Script will auto Run in Edit Mode, and not when in Play Mode if this is Ground

    /// <summary>
    /// Pos on Map this Object
    /// </summary>
    [Header("Pos on Map")]
    public Vector2 v2_Pos = new Vector2();

    /// <summary>
    /// Pos on Environmemt
    /// </summary>
    private Vector3 v3_Pos = new Vector3();
    

    /// <summary>
    /// Check if this Object is Ground (not Character, Burden, etc...)
    /// </summary>
    [Header("Object on Map (Not Ground)")]
    public bool b_isObject = false;

    /// <summary>
    /// Object Front of Ground
    /// </summary>
    public float f_Depth = 1;

    /// <summary>
    /// Object Stand on Centre Ground
    /// </summary>
    public float f_Centre = 0.3f;

    private void Start()
    {
    }

    private void Update()
    {
        Set_Auto();
    }

    /// <summary>
    /// Set on Map Auto on Edit Mode
    /// </summary>
    private void Set_Auto()
    {
        Class_Vector cl_Vector = new Class_Vector();

        if (b_isObject)
        {
            v3_Pos = cl_Vector.Get_Pos_ForIsometric(v2_Pos, f_Depth, f_Centre);
        }
        else
        {
            v3_Pos = cl_Vector.Get_Pos_ForIsometric(v2_Pos);
        }

        this.transform.position = cl_Vector.Get_Pos_PosToIsometric(v3_Pos);
    }

    /// <summary>
    /// Set Pos for this Isometric
    /// </summary>
    /// <param name="v2_Pos"></param>
    public void Set_Pos(Vector2 v2_Pos)
    {
        this.v2_Pos = v2_Pos;
    }

    /// <summary>
    /// Get Pos of this Isometric
    /// </summary>
    /// <returns></returns>
    public Vector2 Get_Pos()
    {
        return v2_Pos;
    }
}
