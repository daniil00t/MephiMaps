using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// Input.mouseScrollDelta example
//
// Create a sphere moved by a mouse scrollwheel or two-finger
// slide on a Mac trackpad.

public class Marks : Structions
{
    public GameObject temp;
    public GameObject tempCnt;
    public GameObject[] corpus;
    private Mark[] ARRAY_MARKS;
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
    public void initMarks(Mark[] arr)
    {
        this.ARRAY_MARKS = arr;
    }
    public struct PositionMark
    {
        public Vector3 Pos;
        public Vector3 Size;
        public PositionMark(Vector3 Pos, Vector3 Size)
        {
            this.Pos = Pos;
            this.Size = Size;
        }
        public Vector3 getPosition()
        {
            Vector3 res = new Vector3(0, 0, 0);
            res.y = Pos.y * 2f + 7f;
            res = new Vector3(Pos.x, res.y, Pos.z);
            return res;
        }
    }
    public void start()
    {
        for (int i = 0; i < this.ARRAY_MARKS.Length; i++)
        {
            Mark mark = ARRAY_MARKS[i];
            temp = GameObject.Find("Mark_Labels/MarkLabel");
            tempCnt = FindObject(GameObject.Find("Mark_Panels"), "Mark_Panel");

            string[] _str = System.Text.RegularExpressions.Regex.Split(mark.place, "-");
            GameObject building = GameObject.Find(_str[0]);
            PositionMark pos_building = new PositionMark(building.transform.position, building.transform.localScale);
            /*pos_building.Pos = building.transform.position;
            pos_building.Size = building.transform.localScale;*/
            //temp.GetComponentsInChildren<GameObject>()[1].SetActive(false);

            try
            {
                renderMark(i, temp, mark, pos_building);
                renderMarkPanel(i, tempCnt, mark);
               
            }
            catch (System.Exception e)
            {
                print(e);
            }


        }

    }

    public void Start()
    {
        Debug.Log("Module Marks is works!");
    }

    public void renderMark(int i, GameObject _tamplate, Mark mark, PositionMark pos_building)
    {
        GameObject go = Instantiate(_tamplate, pos_building.getPosition(), _tamplate.transform.rotation).gameObject;
        go.GetComponentsInChildren<Transform>()[1].GetComponent<TextMeshPro>().SetText($"{mark.id}: {mark.cnt}, {mark.place}");
        go.name = $"Mark_{mark.id}";
        go.transform.parent = GameObject.Find("Mark_Labels").transform;
        go.SetActive(true);
        if (i == this.ARRAY_MARKS.Length - 1) _tamplate.SetActive(false);
    }
    public void renderMarkPanel(int i, GameObject _tamplate, Mark mark)
    {
        print($"i: {i}, Tamplate: {_tamplate.name}, data: [{mark.id}, {mark.cnt}]");
        GameObject goCnt = Instantiate(_tamplate).gameObject;
        goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[1].GetComponent<Text>().text = mark.cnt;
        goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[2].GetComponent<Text>().text = mark.login;
        goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[3].GetComponent<Text>().text = mark._date;
        goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[4].GetComponent<Text>().text = mark.place;

        goCnt.name = $"Mark_Panel_{mark.id}";
        //go.GetComponentsInChildren<Transform>()[1].GetComponent<Renderer>().enabled = true;

        goCnt.transform.parent = GameObject.Find("Mark_Panels").transform;
        
        goCnt.SetActive(false);

        if (i == this.ARRAY_MARKS.Length - 1) _tamplate.SetActive(false);
    }
}