using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// Input.mouseScrollDelta example
//
// Create a sphere moved by a mouse scrollwheel or two-finger
// slide on a Mac trackpad.

public class Marks : Structions
{
    public GameObject temp;
    public GameObject [] corpus;
    private Mark[] ARRAY_MARKS;
    public void initMarks(Mark[] arr)
    {
        this.ARRAY_MARKS = arr;
        Debug.Log(arr[0].id);
    }
    public void start()
    {
        for (int i = 0; i < this.ARRAY_MARKS.Length; i++)
        {
            temp = GameObject.Find("MarkLabel");
            //temp.GetComponentsInChildren<GameObject>()[1].SetActive(false);
            
            //corpus = GameObject.Find("Main").GetComponentsInChildren<GameObject>();

            //GameObject Origin = gameObject;
            //gameObject.GetComponent<Renderer>().enabled = false;



            //Debug.Log(gameObject.transform.position);
            //Debug.Log(gameObject.transform.localScale);
            //Material Material1;
            //Material1.color = Color.red;

            //Debug.Log(_Marks.Length);
            Mark mark = ARRAY_MARKS[i];
            Debug.Log(mark.id);
            GameObject go = Instantiate(temp, temp.transform.position + new Vector3(-10, -10f , 10 * (i + 1) * 3), temp.transform.rotation).gameObject;
            go.GetComponentsInChildren<Transform>()[1].GetComponent<TextMeshPro>().SetText($"{mark.id}: {mark.cnt}, {mark.place}");
            //go.GetComponentsInChildren<Transform>()[1].GetComponent<Renderer>().enabled = true;
            go.SetActive(true);
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
            if (i == this.ARRAY_MARKS.Length - 1) temp.SetActive(false);
        }

    }

    public void Start()
    {
        Debug.Log("Module Marks is works!");
    }

}
