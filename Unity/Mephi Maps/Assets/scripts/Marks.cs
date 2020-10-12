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
    public GameObject [] corpus;
    private Mark[] ARRAY_MARKS;
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
            temp = GameObject.Find("MarkLabel");
            tempCnt = GameObject.Find("Mark_Panel");

            string[] _str = System.Text.RegularExpressions.Regex.Split(mark.place, "-");
            GameObject building = GameObject.Find(_str[0]);
            PositionMark pos_building = new PositionMark(building.transform.position, building.transform.localScale);
            /*pos_building.Pos = building.transform.position;
            pos_building.Size = building.transform.localScale;*/
            //temp.GetComponentsInChildren<GameObject>()[1].SetActive(false);

            //corpus = GameObject.Find("Main").GetComponentsInChildren<GameObject>();

            //GameObject Origin = gameObject;
            //gameObject.GetComponent<Renderer>().enabled = false;



            //Debug.Log(gameObject.transform.position);
            //Debug.Log(gameObject.transform.localScale);
            //Material Material1;
            //Material1.color = Color.red;

            //Debug.Log(_Marks.Length);

            //Debug.Log(pos_building.getPosition());
            try
            {
                GameObject go = Instantiate(temp, pos_building.getPosition(), temp.transform.rotation).gameObject;
                GameObject goCnt = Instantiate(tempCnt).gameObject;

                go.GetComponentsInChildren<Transform>()[1].GetComponent<TextMeshPro>().SetText($"{mark.id}: {mark.cnt}, {mark.place}");

                goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[1].GetComponent<Text>().text = mark.cnt;
                goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[2].GetComponent<Text>().text = mark.login;
                goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[3].GetComponent<Text>().text = mark._date;
                goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[4].GetComponent<Text>().text = mark.place;
                go.name = $"Mark_{mark.id}";
                goCnt.name = $"Mark_Panel_{mark.id}";
                //go.GetComponentsInChildren<Transform>()[1].GetComponent<Renderer>().enabled = true;
                go.SetActive(true);
                goCnt.transform.parent = GameObject.Find("Mark_Panels").transform;
                goCnt.SetActive(false);
                if (i == this.ARRAY_MARKS.Length - 1) temp.SetActive(false);
                if (i == this.ARRAY_MARKS.Length - 1) tempCnt.SetActive(false);
            }
            catch (System.Exception e)
            {
                print(e);
            }
            
            /*Transform[] allChildren = go.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
                textmeshPro.SetText("The first number is {0} and the 2nd is {1:2} and the 3rd is {3:0}.", 4, 6.345f, 3.5f);
                child.gameObject.GetComponent<TextMeshPro>().text = "Danya";
                child.gameObject.GetComponent<Renderer>().enabled = true;
                textmeshPro.gameObject.GetComponent<Renderer>().enabled = true;
            }*/

            //gameObject.GetComponent<Renderer>().enabled = true;
            //go.AddComponent<DestroyAfterPosition>();

            //GameObject tmp = Instantiate(Origin);
            //tmp.transform.position = new Vector3(-1313.3f, 60.4f, -189.5f);
            
        }

    }

    public void Start()
    {
        Debug.Log("Module Marks is works!");
    }

}
