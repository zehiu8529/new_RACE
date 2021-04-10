﻿using UnityEngine;

/// <summary>
/// Working on Vector
/// </summary>
public class Class_Vector
//Vector Primary
{
    public Class_Vector()
    {

    }

    //===1: Distance

    /// <summary>
    /// Receive Distance Between 2 Vector Point
    /// </summary>
    /// <param name="v_Start"></param>
    /// <param name="v_End"></param>
    /// <returns></returns>
    public float Get_Distance(Vector3 v_Start, Vector3 v_End)
    {
        return Vector3.Distance(v_Start, v_End);
    }

    /// <summary>
    /// Receive Distance Between 2 GameObject Point
    /// </summary>
    /// <param name="t_Start"></param>
    /// <param name="t_End"></param>
    /// <returns></returns>
    public float Get_Distance(Transform t_Start, Transform t_End)
    {
        return Vector3.Distance(t_Start.position, t_End.position);
    }

    //===2: Vector on Circle

    //===2.1: Exchance Deg

    /// <summary>
    /// Exchance Rotate Follow Primary
    /// </summary>
    /// <param name="f_DegNeedExchance"></param>
    /// <returns>Return Rotation on Degree</returns>
    public float Get_Exchance_Rotate_Script(float f_DegNeedExchance)
    {
        if (f_DegNeedExchance >= 360)
            return f_DegNeedExchance - 360 * (f_DegNeedExchance / 360);
        else
        if (f_DegNeedExchance <= 0)
            return 360 * (Mathf.Abs(f_DegNeedExchance) / 360 + 1) + f_DegNeedExchance;
        return f_DegNeedExchance;
    }

    /// <summary>
    /// Exchance Rotate Follow Unity
    /// </summary>
    /// <param name="f_DegNeedExchance"></param>
    /// <returns>Return Rotation on Degree</returns>
    public float Get_Exchance_Rotate_Unity(float f_DegNeedExchance)
    {
        if (f_DegNeedExchance <= -180)
            return 360 + f_DegNeedExchance;
        else
        if (f_DegNeedExchance >= 180)
            return (360 - f_DegNeedExchance) * -1;
        return f_DegNeedExchance;
    }

    //=== 2.2: XY

    /// <summary>
    /// Receive Vector Point Based on Circle
    /// </summary>
    /// <param name="f_Angle"></param>
    /// <param name="f_Duration"></param>
    /// <returns></returns>
    public Vector3 Get_DegToVector_XY(float f_Angle, float f_Duration)
    {
        return new Vector3(Mathf.Cos(f_Angle * Mathf.Deg2Rad), Mathf.Sin(f_Angle * Mathf.Deg2Rad), 0) * f_Duration;
    }

    /// <summary>
    /// Receive Dir Between 2 Vector Point
    /// </summary>
    /// <param name="v2_Start"></param>
    /// <param name="v2_End"></param>
    /// <returns></returns>
    public Vector2 Get_Dir_XY(Vector2 v2_Start, Vector2 v2_End)
    {
        return (v2_End - v2_Start).normalized;
    }

    /// <summary>
    /// Receive Offset Rotate Between 2 Vector Dir
    /// </summary>
    /// <param name="v2_DirStart"></param>
    /// <param name="v2_DirEnd"></param>
    /// <returns></returns>
    public float Get_DirToDeg_XY(Vector2 v2_DirStart, Vector2 v2_DirEnd)
    {
        return Vector2.Angle(v2_DirStart, v2_DirEnd);
    }

    //=== 2.3: XZ

    /// <summary>
    /// Receive Vector Point Based on trên Circle
    /// </summary>
    /// <param name="f_Angle"></param>
    /// <param name="f_Duration"></param>
    /// <returns></returns>
    public Vector3 Get_DegToVector_XZ(float f_Angle, float f_Duration)
    {
        return new Vector3(Mathf.Cos(f_Angle * Mathf.Deg2Rad), 0, Mathf.Sin(f_Angle * Mathf.Deg2Rad)) * f_Duration;
    }

    /// <summary>
    /// Receive Dir Between 2 Vector Point
    /// </summary>
    /// <param name="v3_Start"></param>
    /// <param name="v3_End"></param>
    /// <returns></returns>
    public Vector3 Get_Dir_XZ(Vector3 v3_Start, Vector3 v3_End)
    {
        return (v3_End - v3_Start).normalized;
    }

    /// <summary>
    /// Receive Offset Rotate Between 2 Vector Dir
    /// </summary>
    /// <param name="v3_VecStart"></param>
    /// <param name="v3_DirEnd"></param>
    /// <returns></returns>
    public float Get_DirToDeg_XZ(Vector3 v3_VecStart, Vector3 v3_DirEnd)
    {
        Vector2 v2_DirStart = new Vector2(v3_VecStart.x, v3_VecStart.z);
        Vector2 v2_DirEnd = new Vector2(v3_DirEnd.x, v3_DirEnd.z);
        return Vector2.Angle(v2_DirStart, v2_DirEnd);
    }

    /// <summary>
    /// Receive Offset Rotate Between 2 Object, with Main Object Rotate
    /// </summary>
    /// <param name="t_Main"></param>
    /// <param name="t_Check"></param>
    /// <returns></returns>
    public float Get_DirToDeg_XZ_RotateFromTransform(Transform t_Main, Transform t_Check)
    {
        float f_Distance = Vector3.Distance(t_Main.transform.position, t_Check.position);
        float f_Deg = Get_Rot_TransformToVector(t_Main.transform.rotation).y;

        Vector3 v3_DirStart = Get_Dir_XZ(t_Main.transform.position, t_Main.transform.position + Get_DegToVector_XZ(-f_Deg, f_Distance));
        Vector3 v3_DirEnd = Get_Dir_XZ(t_Main.transform.position, t_Main.transform.position + Get_Dir_XZ(t_Main.transform.position, t_Check.position) * f_Distance);

        return Get_DirToDeg_XZ(v3_DirStart, v3_DirEnd);
    }

    //===3: Rotate & Transform Rotate

    /// <summary>
    /// Receive Rotate To Add Transform Rotate
    /// </summary>
    /// <param name="f_DegX_Chance"></param>
    /// <param name="f_DegY_Chance"></param>
    /// <param name="f_DegZ_Chance"></param>
    /// <returns></returns>
    public Quaternion Get_Rot_VectorToTransform(float f_DegX_Chance, float f_DegY_Chance, float f_DegZ_Chance)
    {
        Vector3 v3_RotationVector = new Vector3(f_DegX_Chance, f_DegY_Chance, f_DegZ_Chance);
        Quaternion q_Rotation = Quaternion.Euler(v3_RotationVector);
        return q_Rotation;
    }

    /// <summary>
    /// Receive Rotate To Add Transform Rotate
    /// </summary>
    /// <param name="v3_RotationChance"></param>
    /// <returns></returns>
    public Quaternion Get_Rot_VectorToTransform(Vector3 v3_RotationChance)
    {
        Quaternion q_Rotation = Quaternion.Euler(v3_RotationChance);
        return q_Rotation;
    }

    /// <summary>
    /// Receive Rotate From Transform Rotate [0..360]
    /// </summary>
    /// <param name="q_Rotation"></param>
    /// <returns></returns>
    public Vector3 Get_Rot_TransformToVector(Quaternion q_Rotation)
    {
        Vector3 v3_Rotation = q_Rotation.eulerAngles;
        return v3_Rotation;
    }
}
