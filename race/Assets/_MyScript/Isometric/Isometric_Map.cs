using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Working on Isometric Map Manager
/// </summary>
public class Isometric_Map : MonoBehaviour
{
    //Public

    /// <summary>
    /// Map Code to Load
    /// </summary>
    [Header("Map")]
    public string s_MapCode = "";

    /// <summary>
    /// Map Size to Read
    /// </summary>
    public Vector2Int v2_SizeMap = new Vector2Int(9, 9);

    /// <summary>
    /// List of Ground
    /// </summary>
    [Header("Ground (Prepab 'Isometric_Single')")]
    public List<GameObject> l_Ground;

    /// <summary>
    /// List of Ground
    /// </summary>
    public List<char> l_GroundCode;

    /// <summary>
    /// List of Object ontop of Ground
    /// </summary>
    [Header("Object (Prepab 'Isometric_Single')")]
    public List<GameObject> l_Object;

    /// <summary>
    /// List of Ground
    /// </summary>
    public List<char> l_ObjectCode;

    //Private

    /// <summary>
    /// Class Working on Object
    /// </summary>
    private Class_Object cl_Object;

    //Ground

    /// <summary>
    /// Map Matrix
    /// </summary>
    private List<List<GameObject>> l2_Ground;

    /// <summary>
    /// Map Code Matrix
    /// </summary>
    private List<List<char>> l2_GroundCode;

    //Object

    /// <summary>
    /// Map Matrix
    /// </summary>
    private List<List<GameObject>> l2_Object;

    /// <summary>
    /// Map Code Matrix
    /// </summary>
    private List<List<char>> l2_ObjectCode;

    //Method

    private void Start()
    {
        cl_Object = new Class_Object();

        Set_FirstStart();

        if (s_MapCode != "")
        {
            Set_MapFromCode(s_MapCode);
        }
    }

    //Work

    /// <summary>
    /// First Load Map
    /// </summary>
    private void Set_FirstStart()
    {
        l2_GroundCode = new List<List<char>>();
        l2_ObjectCode = new List<List<char>>();
        l2_Ground = new List<List<GameObject>>();
        l2_Object = new List<List<GameObject>>();

        for (int i = 0; i < v2_SizeMap.x; i++) 
        {
            l2_GroundCode.Add(new List<char>());
            l2_ObjectCode.Add(new List<char>());
            l2_Ground.Add(new List<GameObject>());
            l2_Object.Add(new List<GameObject>());
            for (int j = 0; j < v2_SizeMap.y; j++) 
            {
                l2_GroundCode[i].Add(l_GroundCode[0]);
                l2_ObjectCode[i].Add(l_ObjectCode[0]);

                {
                    GameObject g_Ground = cl_Object.Set_Prepab_Create(l_Ground[0], this.transform);
                    g_Ground.GetComponent<Isometric_Single>().Set_Pos(new Vector2(i, j));
                    g_Ground.GetComponent<Isometric_Single>().b_isObject = false;
                    l2_Ground[i].Add(g_Ground);
                }

                {
                    GameObject g_Object = cl_Object.Set_Prepab_Create(l_Object[0], this.transform);
                    g_Object.GetComponent<Isometric_Single>().Set_Pos(new Vector2(i, j));
                    g_Object.GetComponent<Isometric_Single>().b_isObject = true;
                    l2_Object[i].Add(g_Object);
                }
            }
        }
    }

    //List

    /// <summary>
    /// Count Ground in List
    /// </summary>
    /// <returns></returns>
    public int Get_GroundCount()
    {
        return l_Ground.Count;
    }

    /// <summary>
    /// Count Object in List
    /// </summary>
    /// <returns></returns>
    public int Get_ObjectCount()
    {
        return l_Object.Count;
    }

    //Renderer

    /// <summary>
    /// Get Sprite of Ground in List
    /// </summary>
    /// <param name="i_GroundIndex"></param>
    /// <returns></returns>
    public Sprite Get_GroundSpriteRenderer(int i_GroundIndex)
    {
        return l_Ground[i_GroundIndex].GetComponent<SpriteRenderer>().sprite;
    }

    /// <summary>
    /// Get Sprite of Object in List
    /// </summary>
    /// <param name="i_GroundIndex"></param>
    /// <returns></returns>
    public Sprite Get_ObjectSpriteRenderer(int i_GroundIndex)
    {
        return l_Object[i_GroundIndex].GetComponent<SpriteRenderer>().sprite;
    }

    //Code

    /// <summary>
    /// Get Index of Ground Code
    /// </summary>
    /// <param name="c_GroundCode"></param>
    /// <returns></returns>
    private int Get_GroundCode(char c_GroundCode)
    {
        for(int i = 0; i < l_GroundCode.Count; i++)
        {
            if(l_GroundCode[i] == c_GroundCode)
            {
                return i;
            }
        }
        Debug.LogError("Get_GroundCode: " + c_GroundCode + " Not found!");
        return 0;
    }

    /// <summary>
    /// Get Index of Object Code
    /// </summary>
    /// <param name="c_ObjectCode"></param>
    /// <returns></returns>
    private int Get_ObjectCode(char c_ObjectCode)
    {
        for (int i = 0; i < l_ObjectCode.Count; i++)
        {
            if (l_ObjectCode[i] == c_ObjectCode)
            {
                return i;
            }
        }
        Debug.LogError("Get_ObjectCode: " + c_ObjectCode + " Not found!");
        return 0;
    }

    /// <summary>
    /// Get Code on Map
    /// </summary>
    /// <param name="v2_Pos">Pos to Get Code on Map</param>
    /// <returns>If out Limit, return ' ' (Space)</returns>
    public char Get_MapGroundCode(Vector2Int v2_Pos)
    {
        if(Get_InLimit(v2_Pos))
            return l2_GroundCode[v2_Pos.x][v2_Pos.y];
        return ' ';
    }

    /// <summary>
    /// Get Code on Map
    /// </summary>
    /// <param name="v2_Pos">Pos to Get Code on Map</param>
    /// <returns>If out Limit, return ' ' (Space)</returns>
    public char Get_MapGroundCode(Vector2Int v2_Pos, Vector2Int v2_Dir)
    {
        if (Get_InLimit(v2_Pos, v2_Dir))
            return l2_GroundCode[v2_Pos.x + v2_Dir.x][v2_Pos.y + v2_Dir.y];
        return ' ';
    }

    //Chance

    /// <summary>
    /// Set Ground Chance on 
    /// </summary>
    /// <param name="v2_Pos"></param>
    /// <param name="i_GroundCodeIndex"></param>
    public void Set_GroundChance(Vector2Int v2_Pos, int i_GroundCodeIndex)
    {
        l2_GroundCode[v2_Pos.x][v2_Pos.y] = l_GroundCode[i_GroundCodeIndex];
        l2_Ground[v2_Pos.x][v2_Pos.y].GetComponent<SpriteRenderer>().sprite = Get_GroundSpriteRenderer(i_GroundCodeIndex);
    }

    /// <summary>
    /// Set Object Chance on 
    /// </summary>
    /// <param name="v2_Pos"></param>
    /// <param name="i_GroundCodeIndex"></param>
    public void Set_ObjectChance(Vector2Int v2_Pos, int i_ObjectCodeIndex)
    {
        l2_ObjectCode[v2_Pos.x][v2_Pos.y] = l_ObjectCode[i_ObjectCodeIndex];
        l2_Object[v2_Pos.x][v2_Pos.y].GetComponent<SpriteRenderer>().sprite = Get_ObjectSpriteRenderer(i_ObjectCodeIndex);
    }

    //Code

    /// <summary>
    /// Set Map to Firebase Database at _MapEditor
    /// </summary>
    /// <returns></returns>
    public string Get_MapToCode()
    {
        string s_MapCode = "";

        for(int i = 0; i < v2_SizeMap.x; i++)
        {
            for(int j = 0; j < v2_SizeMap.y; j++)
            {
                s_MapCode += l2_GroundCode[i][j];
            }
        }

        for (int i = 0; i < v2_SizeMap.x; i++)
        {
            for (int j = 0; j < v2_SizeMap.y; j++)
            {
                s_MapCode += l2_ObjectCode[i][j];
            }
        }

        return s_MapCode;
    }

    /// <summary>
    /// Get Map from String Map Code of Firebase Database
    /// </summary>
    /// <param name="s_MapCode"></param>
    public void Set_MapFromCode(string s_MapCode)
    {
        int i_Read = -1;

        for(int i = 0; i < v2_SizeMap.x; i++)
        {
            for(int j = 0; j < v2_SizeMap.y; j++)
            {
                i_Read++;
                l2_GroundCode[i][j] = s_MapCode[i_Read];

                int i_Code = Get_GroundCode(s_MapCode[i_Read]);
                l2_Ground[i][j].GetComponent<SpriteRenderer>().sprite = Get_GroundSpriteRenderer(i_Code);
            }
        }

        for (int i = 0; i < v2_SizeMap.x; i++)
        {
            for (int j = 0; j < v2_SizeMap.y; j++)
            {
                i_Read++;
                l2_ObjectCode[i][j] = s_MapCode[i_Read];

                int i_Code = Get_ObjectCode(s_MapCode[i_Read]);
                l2_Object[i][j].GetComponent<SpriteRenderer>().sprite = Get_ObjectSpriteRenderer(i_Code);
            }
        }

        this.s_MapCode = s_MapCode;
    }

    //Dir

    /// <summary>
    /// Dir(+x,+y) on Environment
    /// </summary>
    /// <returns></returns>
    public Vector2Int Get_DirForward()
    {
        return new Vector2Int(-1, 0);
    }

    /// <summary>
    /// Dir(+x,+y) on Environment
    /// </summary>
    /// <param name="i_Distance">Distance</param>
    /// <returns></returns>
    public Vector2Int Get_DirForward(int i_Distance)
    {
        return new Vector2Int(-1 * i_Distance, 0);
    }

    /// <summary>
    /// Dir(+x,-y) on Environment
    /// </summary>
    /// <returns></returns>
    public Vector2Int Get_DirBackward()
    {
        return new Vector2Int(+1, 0);
    }

    /// <summary>
    /// Dir(+x,-y) on Environment
    /// </summary>
    /// <param name="i_Distance">Distance</param>
    /// <returns></returns>
    public Vector2Int Get_DirBackward(int i_Distance)
    {
        return new Vector2Int(+1 * i_Distance, 0);
    }

    /// <summary>
    /// Dir(-x,-y) on Environment
    /// </summary>
    /// <returns></returns>
    public Vector2Int Get_DirLeft()
    {
        return new Vector2Int(0, -1);
    }

    /// <summary>
    /// Dir(-x,-y) on Environment
    /// </summary>
    /// <param name="i_Distance">Distance</param>
    /// <returns></returns>
    public Vector2Int Get_DirLeft(int i_Distance)
    {
        return new Vector2Int(0, -1 * i_Distance);
    }

    /// <summary>
    /// Dir(+x,+y) on Environment
    /// </summary>
    /// <returns></returns>
    public Vector2Int Get_DirRight()
    {
        return new Vector2Int(0, +1);
    }

    /// <summary>
    /// Dir(+x,+y) on Environment
    /// </summary>
    /// <param name="i_Distance">Distance</param>
    /// <returns></returns>
    public Vector2Int Get_DirRight(int i_Distance)
    {
        return new Vector2Int(0, +1 * i_Distance);
    }

    //Check

    /// <summary>
    /// Check if Pos is In Limit
    /// </summary>
    /// <param name="v2_Pos">Check this Pos if Out Limit</param>
    /// <returns></returns>
    public bool Get_InLimit(Vector2Int v2_Pos)
    {
        if (v2_Pos.x >= v2_SizeMap.x || v2_Pos.x < 0)
            return false;
        if (v2_Pos.y >= v2_SizeMap.y || v2_Pos.y < 0)
            return false;
        return true;
    }

    /// <summary>
    /// Check if Pos is In Limit
    /// </summary>
    /// <param name="v2_Pos">Start Check from Current Pos</param>
    /// <param name="v2_Dir">Check to Dir from Current Pos</param>
    /// <returns></returns>
    public bool Get_InLimit(Vector2Int v2_Pos, Vector2Int v2_Dir)
    {
        if (v2_Pos.x + v2_Dir.x >= v2_SizeMap.x || v2_Pos.x + v2_Dir.x < 0)
            return false;
        if (v2_Pos.y + v2_Dir.y >= v2_SizeMap.y || v2_Pos.y + v2_Dir.y < 0)
            return false;
        return true;
    }
}
