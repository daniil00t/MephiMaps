using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

/* Copyright (C) Xenfinity LLC - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Bilal Itani <bilalitani1@gmail.com>, June 2017
 */

public class Clicker : Structions
{
    private Ray ray;
    private RaycastHit hit;
    private Dictionary<string, int> clickObject = new Dictionary<string, int>() { 
        { "Map", 0 },
        { "Mark_Labels", 1 },
        { "Paths", 2 },
    };
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && !state.Menu && !state.addMarkPanel)
            {
                print($"{hit.point.x}, {hit.point.y}, {hit.point.z}");
                string name = hit.collider.name;
                print(name);
                try
                {
                    Regex rx = new Regex(@"\d+",
                        RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    MatchCollection matches = rx.Matches(name);
                    int idMark = Int32.Parse(matches[0].Value);
                    print(idMark);
                }
                catch (Exception e)
                {
                    print(e);
                }
                
                /*if (System.Text.RegularExpressions.Regex.Split(name, "_")[0] == "Mark")
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
                        else if (hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.name == "Map")
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

                }*/
            }

        }

    }
    private void ActiveMark(int id)
    {
        FindObject(GameObject.Find("Mark_Panels"), $"Mark_Panel_{id}").SetActive(true);
    }
    private void ActiveChangeFloor(string name)
    {
        print($"click {name}");
        //int id = Int32.Parse(Char.ToString(name[name.Length - 1]));
        try
        {
            GameObject el = FindObject(GameObject.Find("2D"), $"ChangeFloor_{name}");
            el.SetActive(true);
        }
        catch (Exception e)
        {
            Debug.LogError($"Кажется, у нас пока нет 2d-карт для этого объекта:( [{e}]");
        }
        
    }
}
