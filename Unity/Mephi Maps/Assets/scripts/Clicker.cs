using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Main_;

/* Copyright (C) Xenfinity LLC - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Bilal Itani <bilalitani1@gmail.com>, June 2017
 */

public class Clicker : Main
{
    private Ray ray;
    private RaycastHit hit;
    public static GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                string name = hit.collider.name;
                if(System.Text.RegularExpressions.Regex.Split(name, "_")[0] == "Mark")
                {
                    ActiveMark(Int32.Parse(Char.ToString(name[name.Length - 1])));
                }
                else
                {
                    try
                    {
                        if (hit.collider.gameObject.transform.parent.gameObject.name == "Map")
                        {
                            ActiveChangeFloor(hit.collider.name);
                        }
                        else if(hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.name == "Map")
                        {
                            ActiveChangeFloor(hit.collider.gameObject.transform.parent.gameObject.name);
                        }
                        else
                        {
                            print($"{hit.collider.gameObject.transform.parent.gameObject.name}, {hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.name}");
                        }
                    }
                    catch (Exception e)
                    {
                        print(e);
                    }
                    
                }
            }
                
        }

    }
    private void ActiveMark(int id)
    {
        //int id = Int32.Parse(Char.ToString(name[name.Length - 1]));
        GameObject tempCntEl = FindObject(GameObject.Find("Mark_Panels"), $"Mark_Panel_{id}");
        //print($"MarkPanel_{id}");
        //print(tempCntEl.name);
        tempCntEl.SetActive(true);
    }
    private void ActiveChangeFloor(string name)
    {
        //int id = Int32.Parse(Char.ToString(name[name.Length - 1]));
        try
        {
            GameObject el = FindObject(GameObject.Find("2D"), $"ChangeFloor_{name}");
            //print($"MarkPanel_{id}");
            //print(tempCntEl.name);
            el.SetActive(true);
        }
        catch (Exception e)
        {
            Debug.LogError($"Кажется, у нас пока нет 2d-карт для этого объекта:( [{e}]");
        }
        
    }
}
